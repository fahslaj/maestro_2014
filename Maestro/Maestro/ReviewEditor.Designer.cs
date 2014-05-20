namespace Maestro
{
    partial class ReviewEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContentLabel = new System.Windows.Forms.Label();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.RatingBar = new System.Windows.Forms.TrackBar();
            this.Rating1 = new System.Windows.Forms.Label();
            this.Rating10 = new System.Windows.Forms.Label();
            this.Rating3 = new System.Windows.Forms.Label();
            this.Rating5 = new System.Windows.Forms.Label();
            this.Rating7 = new System.Windows.Forms.Label();
            this.Rating2 = new System.Windows.Forms.Label();
            this.Rating4 = new System.Windows.Forms.Label();
            this.Rating6 = new System.Windows.Forms.Label();
            this.Rating8 = new System.Windows.Forms.Label();
            this.Rating9 = new System.Windows.Forms.Label();
            this.MediaName = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RatingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Location = new System.Drawing.Point(13, 13);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(135, 17);
            this.ContentLabel.TabIndex = 0;
            this.ContentLabel.Text = "Review Content For:";
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Location = new System.Drawing.Point(13, 43);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(585, 268);
            this.ContentTextBox.TabIndex = 1;
            // 
            // RatingBar
            // 
            this.RatingBar.Location = new System.Drawing.Point(13, 318);
            this.RatingBar.Minimum = 1;
            this.RatingBar.Name = "RatingBar";
            this.RatingBar.Size = new System.Drawing.Size(585, 56);
            this.RatingBar.TabIndex = 2;
            this.RatingBar.Value = 1;
            this.RatingBar.Scroll += new System.EventHandler(this.RatingBar_Scroll);
            // 
            // Rating1
            // 
            this.Rating1.AutoSize = true;
            this.Rating1.Location = new System.Drawing.Point(22, 357);
            this.Rating1.Name = "Rating1";
            this.Rating1.Size = new System.Drawing.Size(16, 17);
            this.Rating1.TabIndex = 3;
            this.Rating1.Text = "1";
            // 
            // Rating10
            // 
            this.Rating10.AutoSize = true;
            this.Rating10.Location = new System.Drawing.Point(572, 357);
            this.Rating10.Name = "Rating10";
            this.Rating10.Size = new System.Drawing.Size(24, 17);
            this.Rating10.TabIndex = 4;
            this.Rating10.Text = "10";
            // 
            // Rating3
            // 
            this.Rating3.AutoSize = true;
            this.Rating3.Location = new System.Drawing.Point(144, 357);
            this.Rating3.Name = "Rating3";
            this.Rating3.Size = new System.Drawing.Size(16, 17);
            this.Rating3.TabIndex = 5;
            this.Rating3.Text = "3";
            // 
            // Rating5
            // 
            this.Rating5.AutoSize = true;
            this.Rating5.Location = new System.Drawing.Point(267, 357);
            this.Rating5.Name = "Rating5";
            this.Rating5.Size = new System.Drawing.Size(16, 17);
            this.Rating5.TabIndex = 6;
            this.Rating5.Text = "5";
            // 
            // Rating7
            // 
            this.Rating7.AutoSize = true;
            this.Rating7.Location = new System.Drawing.Point(391, 357);
            this.Rating7.Name = "Rating7";
            this.Rating7.Size = new System.Drawing.Size(16, 17);
            this.Rating7.TabIndex = 7;
            this.Rating7.Text = "7";
            // 
            // Rating2
            // 
            this.Rating2.AutoSize = true;
            this.Rating2.Location = new System.Drawing.Point(84, 357);
            this.Rating2.Name = "Rating2";
            this.Rating2.Size = new System.Drawing.Size(16, 17);
            this.Rating2.TabIndex = 8;
            this.Rating2.Text = "2";
            // 
            // Rating4
            // 
            this.Rating4.AutoSize = true;
            this.Rating4.Location = new System.Drawing.Point(205, 357);
            this.Rating4.Name = "Rating4";
            this.Rating4.Size = new System.Drawing.Size(16, 17);
            this.Rating4.TabIndex = 9;
            this.Rating4.Text = "4";
            // 
            // Rating6
            // 
            this.Rating6.AutoSize = true;
            this.Rating6.Location = new System.Drawing.Point(330, 357);
            this.Rating6.Name = "Rating6";
            this.Rating6.Size = new System.Drawing.Size(16, 17);
            this.Rating6.TabIndex = 10;
            this.Rating6.Text = "6";
            // 
            // Rating8
            // 
            this.Rating8.AutoSize = true;
            this.Rating8.Location = new System.Drawing.Point(451, 357);
            this.Rating8.Name = "Rating8";
            this.Rating8.Size = new System.Drawing.Size(16, 17);
            this.Rating8.TabIndex = 11;
            this.Rating8.Text = "8";
            // 
            // Rating9
            // 
            this.Rating9.AutoSize = true;
            this.Rating9.Location = new System.Drawing.Point(512, 357);
            this.Rating9.Name = "Rating9";
            this.Rating9.Size = new System.Drawing.Size(16, 17);
            this.Rating9.TabIndex = 12;
            this.Rating9.Text = "9";
            // 
            // MediaName
            // 
            this.MediaName.AutoSize = true;
            this.MediaName.Location = new System.Drawing.Point(155, 13);
            this.MediaName.Name = "MediaName";
            this.MediaName.Size = new System.Drawing.Size(160, 17);
            this.MediaName.TabIndex = 13;
            this.MediaName.Text = "Media Name Goes Here";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(77, 405);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(185, 28);
            this.SubmitButton.TabIndex = 14;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(333, 405);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(185, 28);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ReviewEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 469);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.MediaName);
            this.Controls.Add(this.Rating9);
            this.Controls.Add(this.Rating8);
            this.Controls.Add(this.Rating6);
            this.Controls.Add(this.Rating4);
            this.Controls.Add(this.Rating2);
            this.Controls.Add(this.Rating7);
            this.Controls.Add(this.Rating5);
            this.Controls.Add(this.Rating3);
            this.Controls.Add(this.Rating10);
            this.Controls.Add(this.Rating1);
            this.Controls.Add(this.RatingBar);
            this.Controls.Add(this.ContentTextBox);
            this.Controls.Add(this.ContentLabel);
            this.MaximumSize = new System.Drawing.Size(628, 514);
            this.MinimumSize = new System.Drawing.Size(628, 514);
            this.Name = "ReviewEditor";
            this.Text = "Review Editor";
            ((System.ComponentModel.ISupportInitialize)(this.RatingBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.TrackBar RatingBar;
        private System.Windows.Forms.Label Rating1;
        private System.Windows.Forms.Label Rating10;
        private System.Windows.Forms.Label Rating3;
        private System.Windows.Forms.Label Rating5;
        private System.Windows.Forms.Label Rating7;
        private System.Windows.Forms.Label Rating2;
        private System.Windows.Forms.Label Rating4;
        private System.Windows.Forms.Label Rating6;
        private System.Windows.Forms.Label Rating8;
        private System.Windows.Forms.Label Rating9;
        private System.Windows.Forms.Label MediaName;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
    }
}