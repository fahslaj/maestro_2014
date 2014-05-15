using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    public partial class AddEntryWindow : Form
    {
        private DataTable dt;

        public AddEntryWindow(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
        }

        private void UploadConfirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
