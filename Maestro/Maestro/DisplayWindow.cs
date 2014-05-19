using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;
       // MediaStreamer streamer;
        //SshClient ssh;
        String CurrentUser;
        MediaManager Manager;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
            Manager = new MediaManager();
//            byte[] address = { 137, 112, 128, 188 };
//            streamer = new MediaStreamer(new System.Net.IPAddress(address), 6600, 8000);
            
//            streamer.Play();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)(sender);
            String text = cmb.Text;
            Console.WriteLine(text);
            selectedTable = DBAccessor.selectAllTable(text);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        public void SetUser(string NewUser)
        {
            this.Text = "Maestro: Logged in as " + NewUser;
            this.CurrentUser = NewUser;
            Manager.Login(CurrentUser);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
            Manager.Register(rw.username);
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            AddEntryWindow aew = new AddEntryWindow(selectedTable);
            aew.ShowDialog();
            Manager.streamer.Write("update");
        }

        private void PlaySelectedButton_Click(object sender, EventArgs e)
        {
            PlayMediaWindow pmw = new PlayMediaWindow(Manager.streamer);
            int rowNum = GetSelectedRowNumber();

            if (rowNum >= 0)
            {
                DataRow row = selectedTable.Rows[GetSelectedRowNumber()];
                System.Console.WriteLine(rowNum);
            }
            pmw.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private int GetSelectedRowNumber()
        {
            return dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void DisplayWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentUser != null)
            {
                Manager.streamer.Pause();
                Manager.streamer.Close();
                //Handle killing mpd process
                //String output = ssh.CreateCommand("ps aux | grep 'mpd userconfs/" + this.CurrentUser + ".conf' | cut -c 11-15").Execute();
                String output = Manager.ssh.CreateCommand("cat /run/mpd/" + CurrentUser + ".pid").Execute();
                Manager.ssh.CreateCommand("kill " + output).Execute();

                Manager.ssh.Disconnect();
            }
        }

        private Boolean CloseNextCall = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown || CloseNextCall) { CloseNextCall = false; return; }

            // Confirm user wants to close
            
            switch (MessageBox.Show(this, "Exiting Maestro. \nReturn to the main menu?", "Closing", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.No: 
                    System.Environment.Exit(0); 
                    break;
                default:
                    DisplayManager.ShowMainMenu();
                    CloseNextCall = true;
                    this.Close();
                    break;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Manager.streamer.Play();
            String[] info = Manager.streamer.GetSongInfo();

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            Manager.streamer.Pause();
        }

    }
}
 