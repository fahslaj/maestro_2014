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
            SftpClient sftpClient = new SftpClient("137.112.128.188", "mpd", "mpd");
            SshClient ssh = new SshClient("137.112.128.188", "mpd", "mpd");
            ssh.Connect();
            SshCommand cmd = ssh.CreateCommand("mkdir -p " + "'/var/lib/mpd/music/" + this.ArtistTextbox.Text + "/" + this.albumTextBox.Text + "'");
            cmd.Execute();
            ssh.Disconnect();
            sftpClient.Connect();
            char[] split = { '\\', '\\' };
            String[] path = filepath.Split(split);
            System.IO.FileStream file = new System.IO.FileStream(filepath, System.IO.FileMode.Open);
            String uploadFilepath = this.ArtistTextbox.Text + "/" + this.albumTextBox.Text + "/" + path[path.Length - 1];
            uploadFilepath.Replace(" ", "\\ ");
            DBAccessor.insertEntry("'" + uploadFilepath + "'|'" + this.NameTextBox.Text + "'|'" + this.ArtistTextbox.Text + "'|NULL|'" + GenreTextBox.Text + "'|'" + TypeBox.Text + "'|'" + 300 + "'|" + ReleaseDateBox.Text, "Media");
            try
            {
                sftpClient.UploadFile(file, "/var/lib/mpd/music/" + uploadFilepath);
            }
            catch (Renci.SshNet.Common.SshException sshe)
            {
                System.Console.WriteLine(sshe.Message);
            }
            file.Close();
            sftpClient.Disconnect();
            this.Close();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            filepath = "";
            if (ChooseFileDialog.ShowDialog() == DialogResult.OK)
                filepath = ChooseFileDialog.FileName;
            Console.WriteLine(filepath);
        }
    }
}