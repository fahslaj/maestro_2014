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
using System.IO;

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
            this.Text = "Maestro: Logged on as " + NewUser;
            this.CurrentUser = NewUser;
            Manager.Login(CurrentUser);
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

        private void DisplayWindow_FormClosed(object sender = null, FormClosedEventArgs e = null)
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

        protected override void OnFormClosing(FormClosingEventArgs e = null)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown || CloseNextCall) 
            { 
                CloseNextCall = false; 
                this.DisplayWindow_FormClosed(); 
                return; 
            }

            // Confirm user wants to close
            
            switch (MessageBox.Show(this, "Exiting Maestro. \nReturn to the main menu?", "Closing", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.No:
                    this.DisplayWindow_FormClosed();
                    System.Environment.Exit(0); 
                    break;
                default:
                    ReturnToMainMenu();
                    break;
            }
        }

        private void ReturnToMainMenu()
        {
            DisplayManager.ShowMainMenu();
            CloseNextCall = true;
            this.Close();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("Play pressed");
            Manager.streamer.Play();
            //String[] info = Manager.streamer.GetSongInfo();
            
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("Pause pressed");
            Manager.streamer.Pause();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Manager.streamer.Back();
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            Manager.streamer.Skip();
        }

        private void songToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEntryWindow aew = new AddEntryWindow(selectedTable);
            aew.ShowDialog();
            Manager.streamer.Write("update");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisplayWindow_FormClosed();
            System.Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        private void MuteUnmuteButton_Click(object sender, EventArgs e)
        {
            if (Manager.streamer.Muted)
            {
                Manager.streamer.UnMute();
                this.MuteUnmuteButton.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\Unmute Button.png");
            }
            else
            {
                Manager.streamer.Mute();
                this.MuteUnmuteButton.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\Mute Button.png");
            }
            /*
            foreach (var path in Directory.GetFiles("..\\..\\Resources\\Unmute Button.png"))
            {
                Console.WriteLine(path); // full path
                Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
            }*/
        }


    }
}
 