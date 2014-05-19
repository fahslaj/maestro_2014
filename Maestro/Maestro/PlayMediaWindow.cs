using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    class PlayMediaWindow : Form
    {
        private PictureBox ImageDisplayerBox;
        private Button PlayButton;
        private Button Pausebutton;
        MediaStreamer streamer;

        public PlayMediaWindow(MediaStreamer streamer)
        {
            this.streamer = streamer;
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMediaWindow));
            this.ImageDisplayerBox = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.Pausebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageDisplayerBox
            // 
            this.ImageDisplayerBox.Image = ((System.Drawing.Image)(resources.GetObject("ImageDisplayerBox.Image")));
            this.ImageDisplayerBox.Location = new System.Drawing.Point(-3, -4);
            this.ImageDisplayerBox.Name = "ImageDisplayerBox";
            this.ImageDisplayerBox.Size = new System.Drawing.Size(393, 406);
            this.ImageDisplayerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageDisplayerBox.TabIndex = 0;
            this.ImageDisplayerBox.TabStop = false;
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(72, 347);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(51, 26);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Pausebutton
            // 
            this.Pausebutton.Location = new System.Drawing.Point(129, 347);
            this.Pausebutton.Name = "Pausebutton";
            this.Pausebutton.Size = new System.Drawing.Size(60, 26);
            this.Pausebutton.TabIndex = 2;
            this.Pausebutton.Text = "Pause";
            this.Pausebutton.UseVisualStyleBackColor = true;
            this.Pausebutton.Click += new System.EventHandler(this.Pausebutton_Click);
            // 
            // PlayMediaWindow
            // 
            this.ClientSize = new System.Drawing.Size(938, 398);
            this.Controls.Add(this.Pausebutton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ImageDisplayerBox);
            this.Name = "PlayMediaWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayerBox)).EndInit();
            this.ResumeLayout(false);

        }

        private void SeekBar_Click(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            streamer.Play();
            String[] info = streamer.GetSongInfo();
            
        }

        private void Pausebutton_Click(object sender, EventArgs e)
        {
            streamer.Pause();
        }


    }
}
