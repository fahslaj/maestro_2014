﻿using System;
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
        string filepath;

        public AddEntryWindow(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
        }

        private void UploadConfirmButton_Click(object sender, EventArgs e)
        {

        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            filepath = "";
            if (ChooseFileDialog.ShowDialog() == DialogResult.OK)
                filepath = ChooseFileDialog.FileName;
            Console.WriteLine(filepath);

            TagLib.File tagFile = TagLib.File.Create(filepath);

            this.NameTextBox.Text = tagFile.Tag.Title;
            this.ArtistTextbox.Text = tagFile.Tag.FirstPerformer;
            this.albumTextBox.Text = tagFile.Tag.Album;
            this.GenreTextBox.Text = tagFile.Tag.FirstGenre;
            this.ReleaseDateBox.Text = tagFile.Tag.Year + "";

            System.Console.WriteLine(tagFile.Properties.Duration + "");
        }
    }
}
