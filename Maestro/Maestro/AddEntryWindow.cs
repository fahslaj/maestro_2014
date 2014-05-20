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
        }
    }
}
