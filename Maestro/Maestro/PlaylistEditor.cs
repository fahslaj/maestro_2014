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
        public DataTable CurrentTable;

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
                DataTable dt = DBAccessor.selectAllWhere("PlaylistView", "[Playlist Name]", PlaylistName);
                foreach (DataRow dr in dt.Rows)
                    if (((int)dr["PlaylistIndex"]) > this.PlaylistSize)
                        this.PlaylistSize = (int)dr["PlaylistIndex"];
            }
        }

        public void SetPlaylist(string PlaylistName)
        {
            this.PlaylistName = PlaylistName;
            this.PlaylistNameBox.Text = PlaylistName;
            DataTable dt = DBAccessor.selectAllWhere("PlaylistView", "[Playlist Name]", PlaylistName);
            foreach (DataRow dr in dt.Rows)
                if (((int)dr["PlaylistIndex"]) > this.PlaylistSize)
                    this.PlaylistSize = (int)dr["PlaylistIndex"];
            UpdateTables();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataTable search;
            search = DBAccessor.selectSearchTable("PlaylistView", this.SearchBox.Text);
            this.AllMediaDataGrid.DataSource = new BindingSource(search, null);
        }

        private void ShiftUpButton_Click(object sender, EventArgs e)
        {
            /*
            int firstRow = this.CurrentPlaylistDataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (firstRow == -1)
                return;
            int index = (int)this.CurrentPlaylistDataGrid.Rows[firstRow].Cells["PlaylistIndex"].Value;
            if (index <= 0)
                return;
            DBAccessor.updateEntry("Belongs_To", CurrentTable.Rows[firstRow], "PlaylistIndex = " + (index - 1));*/
        }

        private void ShiftDownButton_Click(object sender, EventArgs e)
        {
            /*
            int firstRow = this.CurrentPlaylistDataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (firstRow == -1)
                return;
            int index = (int)this.CurrentPlaylistDataGrid.Rows[firstRow].Cells["PlaylistIndex"].Value;
            DBAccessor.updateEntry("Belongs_To", CurrentTable.Rows[firstRow], "PlaylistIndex = " + (index + 1));*/
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int firstRow = this.CurrentPlaylistDataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (firstRow == -1)
                return;
            DBAccessor.deleteEntry("Belongs_To", "MediaFilepath = '"+(string)CurrentPlaylistDataGrid.Rows[firstRow].Cells["MediaFilepath"].Value +"' and PlaylistAuthor = '"+this.Username+"'");
            UpdateTables();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreatePlaylist()
        {
            DBAccessor.AddPlaylist(this.Username, this.PlaylistName);
        }

        private void UpdateTables()
        {
            DataTable dt = DBAccessor.selectAllWhere("PlaylistView", "[Playlist Name]", PlaylistName);
            CurrentTable = dt;
            this.CurrentPlaylistDataGrid.DataSource = new BindingSource(dt, null);

            dt = DBAccessor.selectAllTable("MediaView");
            this.AllMediaDataGrid.DataSource = new BindingSource(dt, null);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int firstRow = AllMediaDataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (firstRow == -1)
                return;
            DBAccessor.insertEntry("'" + AllMediaDataGrid.Rows[firstRow].Cells["Filepath"].Value + "'|'" +
                    this.Username + "'|'" + this.PlaylistName+"'|"+(this.PlaylistSize++), "Belongs_To");
            UpdateTables();
        }
    }
}
