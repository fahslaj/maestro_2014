using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Maestro
{
    public partial class PlaylistEditor : Form
    {
        public string PlaylistName;
        private string Username;
        public int PlaylistSize = 0;

        public PlaylistEditor(string username, Boolean isCreation = false)
        {
            this.Username = username;
            InitializeComponent();
            if (isCreation)
            {
                this.PlaylistName = Interaction.InputBox("Enter playlist name:", "Playlist Editor", "");
                this.PlaylistNameBox.Text = this.PlaylistName;
                CreatePlaylist();
                UpdateTables();
            }
        }

        public void SetPlaylist(string PlaylistName)
        {
            this.PlaylistName = PlaylistName;
            this.PlaylistNameBox.Text = PlaylistName;
            UpdateTables();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void ShiftUpButton_Click(object sender, EventArgs e)
        {

        }

        private void ShiftDownButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.PlaylistName = this.PlaylistNameBox.Text;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreatePlaylist()
        {
            DBAccessor.AddPlaylist(this.Username, this.PlaylistName);
        }

        private void UpdateTables()
        {
            DataTable dt = DBAccessor.selectAllWhere("Playlist JOIN Belongs_To on Playlist.Name = Belongs_To.PlaylistName and Playlist.Author = Belongs_To.PlaylistAuthor", "Name", PlaylistName);
            foreach (DataRow dr in dt.Rows)
                if (((int)dr["PlaylistIndex"]) > this.PlaylistSize)
                    this.PlaylistSize = (int)dr["PlaylistIndex"];
            this.CurrentPlaylistDataGrid.DataSource = new BindingSource(dt, null);

            dt = DBAccessor.selectAllTable("MediaView");
            this.AllMediaDataGrid.DataSource = new BindingSource(dt, null);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int firstRow = AllMediaDataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            DBAccessor.insertEntry("'" + AllMediaDataGrid.Rows[firstRow].Cells["Filepath"].Value + "'|'" +
                    this.Username + "'|'" + this.PlaylistName+"'|"+(++this.PlaylistSize), "Belongs_To");
            UpdateTables();
        }
    }
}
