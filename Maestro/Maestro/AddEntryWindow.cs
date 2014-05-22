using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace Maestro
{
    public partial class AddEntryWindow : Form
    {
        private DataTable dt;
        public string filepath;
        public string name;
        public string artist;
        public string album;
        public string genre;
        public int length;
        public int releaseDate;
        public int track_no;
        private Boolean noSave = true;

        public AddEntryWindow(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
            this.TypeBox.Text = "Song";
        }

        private void UploadConfirmButton_Click(object sender, EventArgs e)
        {
            name = this.NameTextBox.Text;
            artist = this.ArtistTextbox.Text;
            genre = this.GenreTextBox.Text;
            album = this.albumTextBox.Text;
            track_no = int.Parse(this.Track_NoBox.Text);
            releaseDate = int.Parse(this.ReleaseDateBox.Text);
            noSave = false;
            this.Close();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            filepath = "";
            if (ChooseFileDialog.ShowDialog() == DialogResult.OK)
                filepath = ChooseFileDialog.FileName;
            if (filepath == "")
                return;
            Console.WriteLine(filepath);

            TagLib.File tagFile = TagLib.File.Create(filepath);

            this.NameTextBox.Text = tagFile.Tag.Title;
            this.ArtistTextbox.Text = tagFile.Tag.FirstPerformer;
            this.albumTextBox.Text = tagFile.Tag.Album;
            this.GenreTextBox.Text = tagFile.Tag.FirstGenre;
            this.ReleaseDateBox.Text = tagFile.Tag.Year + "";
            this.Track_NoBox.Text = tagFile.Tag.Track + "";
            length = (int)tagFile.Properties.Duration.TotalSeconds;

            System.Console.WriteLine(tagFile.Properties.Duration + "");
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            if (noSave)
            {
                System.Console.WriteLine("Exited with X button");
                this.filepath = "";
            }
        }
    }
}
