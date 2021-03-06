﻿using System;
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
        String CurrentTable;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
            Manager = new MediaManager();
            CurrentTable = "SongView";
            selectedTable = DBAccessor.selectAllTable(CurrentTable);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["Filepath"].Visible = false;
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

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            //GetSelectedRowNumber();
            AddEntryWindow aew = new AddEntryWindow(selectedTable);
            aew.ShowDialog();
            
            Manager.streamer.Write("update");
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
            if (GetSelectedRowNumber() < 0)
                return null;
            string s = (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["Title"].Value;
            
            return s;
        }

        private string GetSelectedMediaFilepath()
        {
            if (GetSelectedRowNumber() < 0)
                return null;
            if (dataGridView1.Columns.Contains("Filepath"))
                return (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["Filepath"].Value;
            else if (dataGridView1.Columns.Contains("MediaFilepath"))
                return (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["MediaFilepath"].Value;
            return null;
        }

        private string GetSelectedReviewContent()
        {
            if (GetSelectedRowNumber() < 0)
                return null;
            string s = (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["Content"].Value;

            return s;
        }

        private string GetSelectedReviewMedia()
        {
            if (GetSelectedRowNumber() < 0)
                return null;
            string s = "No Name";
            if (dataGridView1.Columns.Contains("Name"))
                s =  (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["Name"].Value;
            else if (dataGridView1.Columns.Contains("MediaName"))
                s = (string)dataGridView1.Rows[GetSelectedRowNumber()].Cells["MediaName"].Value;

            return s;
        }

        private int GetSelectedReviewRating()
        {
            if (GetSelectedRowNumber() < 0)
                return 0;
            int s = (int)dataGridView1.Rows[GetSelectedRowNumber()].Cells["Rating"].Value;

            return s;
        }

        private void DisplayWindow_FormClosed(object sender = null, FormClosedEventArgs e = null)
        {
            if (CurrentUser != null)
            {
                try
                {
                    //Manager.streamer.Pause();
                    Manager.streamer.Close();
                    //Handle killing mpd process
                    //String output = ssh.CreateCommand("ps aux | grep 'mpd userconfs/" + this.CurrentUser + ".conf' | cut -c 11-15").Execute();
                    String output = Manager.ssh.CreateCommand("cat /run/mpd/" + CurrentUser + ".pid").Execute();
                    Manager.ssh.CreateCommand("kill " + output).Execute();

                    Manager.ssh.Disconnect();
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex);
                    return;
                }
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
            //this.DisplayWindow_FormClosed();
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
            Console.WriteLine(aew.album + " " + aew.name + " " + aew.artist);
            Manager.UploadSong(aew.filepath, aew.artist, aew.album, aew.name, aew.genre, aew.releaseDate, aew.length, CurrentUser, aew.track_no);
            /*Manager.streamer.Refresh();
            Manager.streamer.Write("update");
            Manager.streamer.CloseControlStream();*/
            Manager.streamer.Update();
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
            if (GetSelectedMediaName() == null)
                return;
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
                if(re.submit) DBAccessor.UpdateReview(this.CurrentUser, this.GetSelectedMediaFilepath(),
                    this.GetSelectedReviewRating(), re.Content);
            }
            //item has already been reviewed, so it can't be reviewed again
            else if (reviewType == 2)
            {
                MessageBox.Show("You have already reviewed this item!");
            }
        }

        private void searchMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("MediaView");
            CurrentTable = "MediaView";

            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["Filepath"].Visible = false;
        }

        private void createNewPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistEditor pe = new PlaylistEditor(this.CurrentUser, true);
            pe.Show();
        }

        private void myPlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.getMyPlaylists(this.CurrentUser);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void followPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string author = (string) this.dataGridView1.Rows[GetSelectedRowNumber()].Cells["Author"].Value;
            DateTime date = (DateTime) this.dataGridView1.Rows[GetSelectedRowNumber()].Cells["DateCreated"].Value;
            DBAccessor.follow(this.CurrentUser, author, date);
        }

        private void searchReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("ReviewView");
            CurrentTable = "ReviewView";

            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void showCurrentPlayQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] playlist = Manager.streamer.GetInternalPlaylist();
            if (playlist == null) return;
            String attributes = "";
            for (int i = 0; i < playlist.Length; i++)
            {
                attributes += "Filepath='" + playlist[i] + "'";
                if (i < playlist.Length - 1)
                {
                    attributes += " OR ";
                }
            }
            
            DataTable table = DBAccessor.selectCurrentPlaylist(attributes);
            table.Columns.Add("Order");
            //table.PrimaryKey = new DataColumn[]{table.Columns[0]};
            int ind = -1;
            for (int i = 0; i < playlist.Length; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    System.Console.WriteLine(table.Rows[j].Field<String>(0));
                    if (table.Rows[j].Field<String>(0) == playlist[i])
                    {
                        ind = j;
                        break;
                    }
                }
                //int ind = table.Rows.IndexOf(table.Rows.Find(playlist[i]));
                table.Rows[ind].SetField<int>(table.Columns[table.Columns.Count - 1], i+1);
            }
            table.Columns.Remove("Filepath");
            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void editPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistEditor pe = new PlaylistEditor(CurrentUser);
            if (GetSelectedRowNumber() == -1)
                return;
            if ((string)this.dataGridView1.Rows[GetSelectedRowNumber()].Cells["Author"].Value != this.CurrentUser)
            {
                MessageBox.Show("You may not edit other users' playlists!");
                return;
            }
            pe.SetPlaylist((string)this.dataGridView1.Rows[GetSelectedRowNumber()].Cells["Name"].Value);
            pe.Show();
        }

        private void searchAllPlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("Playlist");
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void myReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectedTable = DBAccessor.selectAllWhere("Reviews", "Username", this.CurrentUser);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void addFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fp = (string) dataGridView1.Rows[GetSelectedRowNumber()].Cells["Filepath"].Value;
            if(fp != null) DBAccessor.addFavorite(this.CurrentUser, fp);
        }

        private void getFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFavorites();
        }

        private void PlayNext_Click(object sender, EventArgs e)
        {
            String path = GetSelectedMediaFilepath();
            if (path == null)
                return;
            Manager.streamer.Add(path);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //TODO search through all media for keywords
            selectedTable = DBAccessor.selectSearchTable(selectedTable.TableName, this.SearchBar.Text);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["Filepath"].Visible = false;
        }

        private void albumToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void searchSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTable = DBAccessor.selectAllTable("SongView");
            CurrentTable = "SongView";
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["Filepath"].Visible = false;
        }

        private void showReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReviewEditor re = new ReviewEditor(GetSelectedReviewMedia(), true);
            re.SetContentAndRating(GetSelectedReviewContent(), GetSelectedReviewRating());
            re.Show();
        }

        private void clearCurrentPlayQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.streamer.Clear();
        }

        private void unsubscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure?\nThis will remove you account.", "Warning", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    Manager.Unregister(CurrentUser);
                    MessageBox.Show("You are now unsubscribed from Maestro.");
                    ReturnToMainMenu();
                    break;
                default:
                    break;
            }
        }

        private void addToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Contains("Filepath"))
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    Manager.streamer.Add((string)this.dataGridView1.Rows[i].Cells["Filepath"].Value);
            else if (dataGridView1.Columns.Contains("MediaFilepath"))
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    Manager.streamer.Add((string)this.dataGridView1.Rows[i].Cells["MediaFilepath"].Value);
       }

        private void expandPlaylistToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int index = GetSelectedRowNumber();
            if (index == -1)
                return;
            selectedTable = DBAccessor.selectAllWhere("PlaylistView", "Author = '" + this.CurrentUser +
                "' and [Playlist Name]", (string)this.dataGridView1.Rows[index].Cells["Name"].Value);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["MediaFilepath"].Visible = false;
        }

        private void unFollowPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetSelectedRowNumber();
            if (index == -1)
                return;
            DBAccessor.deleteEntry("Follows", "Username = '" + this.CurrentUser + "' and PlaylistDateCreated = '"
                + (DateTime) this.dataGridView1.Rows[index].Cells["DateCreated"].Value + "' and PlaylistAuthor = '"
                + (string) this.dataGridView1.Rows[index].Cells["Author"].Value + "'");
            selectFollowed();
        }

        private void removeFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetSelectedRowNumber();
            if (index == -1)
                return;
            DBAccessor.deleteEntry("Likes", "Username = '" + this.CurrentUser + "' and MediaFilepath = '"
                + (string)this.dataGridView1.Rows[index].Cells["MediaFilepath"].Value + "'"); 
            selectFavorites();
        }

        private void followedPlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFollowed();
        }

        private void selectFollowed()
        {
            selectedTable = DBAccessor.selectAllWhere("Follows Join Playlist on Follows.PlaylistAuthor = Playlist.Author"
                + " AND Follows.PlaylistDateCreated = Playlist.DateCreated", "Follows.Username", this.CurrentUser);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["PlaylistAuthor"].Visible = false;
            dataGridView1.Columns["PlaylistDateCreated"].Visible = false;
        }

        private void selectFavorites()
        {
            selectedTable = DBAccessor.getFavorites(this.CurrentUser);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
            dataGridView1.Columns["MediaFilepath"].Visible = false;
        }

        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
 