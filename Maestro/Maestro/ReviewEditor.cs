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
        public bool submit; //ensures db is only affected through the Submit button
        private bool submittable;

        public ReviewEditor(string MediaName, bool forDisplay=false)
        {
            InitializeComponent();
            this.submit = false;
            this.MediaName.Text = MediaName;
            this.submittable = !forDisplay;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (this.submittable)
            {
                this.Content = ContentTextBox.Text;
                this.submit = true;
                this.Close();
            }
        }

        public void SetContentAndRating(string content, int rating)
        {
            this.Content = content;
            this.ContentTextBox.Text = this.Content;
            this.Rating = rating;
            this.RatingBar.Value = this.Rating;
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
