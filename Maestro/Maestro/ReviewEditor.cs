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
    public partial class ReviewEditor : Form
    {
        public string Content;
        public int Rating;

        public ReviewEditor(string MediaName)
        {
           InitializeComponent();
            this.MediaName.Text = MediaName;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Content = ContentLabel.Text;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RatingBar_Scroll(object sender, EventArgs e)
        {
            this.Rating = ((TrackBar)(sender)).Value;
        }
    }
}
