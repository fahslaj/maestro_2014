using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Maestro
{
    class PlayMediaWindow : Form
    {
        private PictureBox ImageDisplayerBox;
        private Button PlayButton;
        private Button PauseButton;
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
            this.PauseButton = new System.Windows.Forms.Button();
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
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(114, 306);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(40, 40);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(213, 306);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(40, 40);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.Pausebutton_Click);
            // 
            // PlayMediaWindow
            // 
            this.ClientSize = new System.Drawing.Size(389, 398);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ImageDisplayerBox);
            this.Name = "PlayMediaWindow";
            this.Text = "Maestro: Media Window";
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
