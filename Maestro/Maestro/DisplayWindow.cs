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
            selectedTable = DBAccessor.selectAllTable("Media");
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
//            byte[] address = { 137, 112, 128, 188 };
//            streamer = new MediaStreamer(new System.Net.IPAddress(address), 6600, 8000);
            
//            streamer.Play();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)(sender);
            String text = cmb.Text;
            Console.WriteLine(text);
            //GetSelectedRowNumber();
            selectedTable = DBAccessor.selectAllTable(text);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        public void SetUser(string NewUser)
        {
            this.Text = "Maestro: Logged on as " + NewUser;
            this.CurrentUser = NewUser;
            Manager.Login(CurrentUser);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            GetSelectedRowNumber();
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
            Manager.Register(rw.username);
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            //GetSelectedRowNumber();
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

        //Gets the (0-based) index of the first fully highlighted row
        public int GetSelectedRowNumber()
        {
            int firstRow = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            System.Console.WriteLine("first selected row index: " + firstRow);
            return firstRow;
        }

        private string GetSelectedMediaName()
        {
            return (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells[1].Value;
        }

        private string GetSelectedMediaFilepath()
        {
            return (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells[0].Value;
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
                Manager.streamer.Unmute();
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

        private void writeReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReviewEditor re = new ReviewEditor(GetSelectedMediaName());
            int reviewType = DBAccessor.CheckReviewValidity(this.CurrentUser, this.GetSelectedMediaFilepath());
            //rating and content are both null, so no special case
            if (reviewType == 0)
            {
                re.ShowDialog();
                if(re.submit) DBAccessor.AddReview(this.CurrentUser, this.GetSelectedMediaFilepath(), re.Rating, re.Content);
            }
            //rating is not null but content is, so this review needs to be updated, not inserted
            else if (reviewType == 1)
            {
                re.RatingBar.Value = DBAccessor.GetCurrentRating(this.CurrentUser, this.GetSelectedMediaFilepath());
                re.ShowDialog();
                if(re.submit) DBAccessor.UpdateReview(this.CurrentUser, this.GetSelectedMediaFilepath(), re.Rating, re.Content);
            }
            //item has already been reviewed, so it can't be reviewed again
            else if (reviewType == 2)
            {
                MessageBox.Show("You have already reviewed this item!");
            }
        }

        private void searchMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("Media");
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void createNewPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistEditor pe = new PlaylistEditor();
            pe.Show();
        }

        private void searchReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("Reviews");
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void showCurrentPlayQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] playlist = Manager.streamer.GetInternalPlaylist();
            String attributes = "";
            for (int i = 0; i < playlist.Length; i++)
            {
                attributes += "Filepath='" + playlist[i] + "'";
                if (i < playlist.Length - 1)
                {
                    attributes += " OR ";
                }
            }
            selectedTable = DBAccessor.selectCurrentPlaylist(attributes);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }


    }
}
 