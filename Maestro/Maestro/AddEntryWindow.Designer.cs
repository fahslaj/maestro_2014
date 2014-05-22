namespace Maestro
{
    partial class AddEntryWindow
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ArtistTextbox = new System.Windows.Forms.TextBox();
            this.GenreTextBox = new System.Windows.Forms.TextBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.ReleaseDateBox = new System.Windows.Forms.TextBox();
            this.ReleaseDateLabel = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ChooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileButton = new System.Windows.Forms.Button();
            this.UploadConfirmButton = new System.Windows.Forms.Button();
            this.albumName = new System.Windows.Forms.Label();
            this.albumTextBox = new System.Windows.Forms.TextBox();
            this.Track_NoBox = new System.Windows.Forms.TextBox();
            this.Track_NoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 49);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Location = new System.Drawing.Point(13, 103);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(40, 17);
            this.ArtistLabel.TabIndex = 1;
            this.ArtistLabel.Text = "Artist";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(16, 69);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(297, 22);
            this.NameTextBox.TabIndex = 2;
            // 
            // ArtistTextbox
            // 
            this.ArtistTextbox.Location = new System.Drawing.Point(16, 123);
            this.ArtistTextbox.Name = "ArtistTextbox";
            this.ArtistTextbox.Size = new System.Drawing.Size(297, 22);
            this.ArtistTextbox.TabIndex = 3;
            // 
            // GenreTextBox
            // 
            this.GenreTextBox.Location = new System.Drawing.Point(16, 181);
            this.GenreTextBox.Name = "GenreTextBox";
            this.GenreTextBox.Size = new System.Drawing.Size(297, 22);
            this.GenreTextBox.TabIndex = 5;
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Location = new System.Drawing.Point(13, 161);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(48, 17);
            this.GenreLabel.TabIndex = 4;
            this.GenreLabel.Text = "Genre";
            // 
            // ReleaseDateBox
            // 
            this.ReleaseDateBox.Location = new System.Drawing.Point(16, 239);
            this.ReleaseDateBox.Name = "ReleaseDateBox";
            this.ReleaseDateBox.Size = new System.Drawing.Size(297, 22);
            this.ReleaseDateBox.TabIndex = 7;
            // 
            // ReleaseDateLabel
            // 
            this.ReleaseDateLabel.AutoSize = true;
            this.ReleaseDateLabel.Location = new System.Drawing.Point(13, 219);
            this.ReleaseDateLabel.Name = "ReleaseDateLabel";
            this.ReleaseDateLabel.Size = new System.Drawing.Size(138, 17);
            this.ReleaseDateLabel.TabIndex = 6;
            this.ReleaseDateLabel.Text = "Release Date (Year)";
            // 
            // TypeBox
            // 
            this.TypeBox.Location = new System.Drawing.Point(16, 299);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(297, 22);
            this.TypeBox.TabIndex = 9;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(13, 279);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(40, 17);
            this.TypeLabel.TabIndex = 8;
            this.TypeLabel.Text = "Type";
            // 
            // ChooseFileDialog
            // 
            this.ChooseFileDialog.FileName = "ChooseFileDialogName";
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(16, 12);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(91, 23);
            this.FileButton.TabIndex = 10;
            this.FileButton.Text = "Choose File";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // UploadConfirmButton
            // 
            this.UploadConfirmButton.Location = new System.Drawing.Point(16, 392);
            this.UploadConfirmButton.Name = "UploadConfirmButton";
            this.UploadConfirmButton.Size = new System.Drawing.Size(108, 23);
            this.UploadConfirmButton.TabIndex = 11;
            this.UploadConfirmButton.Text = "Upload File";
            this.UploadConfirmButton.UseVisualStyleBackColor = true;
            this.UploadConfirmButton.Click += new System.EventHandler(this.UploadConfirmButton_Click);
            // 
            // albumName
            // 
            this.albumName.AutoSize = true;
            this.albumName.Location = new System.Drawing.Point(14, 333);
            this.albumName.Name = "albumName";
            this.albumName.Size = new System.Drawing.Size(47, 17);
            this.albumName.TabIndex = 12;
            this.albumName.Text = "Album";
            // 
            // albumTextBox
            // 
            this.albumTextBox.Location = new System.Drawing.Point(16, 353);
            this.albumTextBox.Name = "albumTextBox";
            this.albumTextBox.Size = new System.Drawing.Size(297, 22);
            this.albumTextBox.TabIndex = 13;
            // 
            // Track_NoBox
            // 
            this.Track_NoBox.Location = new System.Drawing.Point(226, 12);
            this.Track_NoBox.Name = "Track_NoBox";
            this.Track_NoBox.Size = new System.Drawing.Size(87, 22);
            this.Track_NoBox.TabIndex = 14;
            // 
            // Track_NoLabel
            // 
            this.Track_NoLabel.AutoSize = true;
            this.Track_NoLabel.Location = new System.Drawing.Point(154, 12);
            this.Track_NoLabel.Name = "Track_NoLabel";
            this.Track_NoLabel.Size = new System.Drawing.Size(66, 17);
            this.Track_NoLabel.TabIndex = 15;
            this.Track_NoLabel.Text = "Track No";
            // 
            // AddEntryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 427);
            this.Controls.Add(this.Track_NoLabel);
            this.Controls.Add(this.Track_NoBox);
            this.Controls.Add(this.albumTextBox);
            this.Controls.Add(this.albumName);
            this.Controls.Add(this.UploadConfirmButton);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ReleaseDateBox);
            this.Controls.Add(this.ReleaseDateLabel);
            this.Controls.Add(this.GenreTextBox);
            this.Controls.Add(this.GenreLabel);
            this.Controls.Add(this.ArtistTextbox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ArtistLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "AddEntryWindow";
            this.Text = "AddEntryWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ArtistTextbox;
        private System.Windows.Forms.TextBox GenreTextBox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.TextBox ReleaseDateBox;
        private System.Windows.Forms.Label ReleaseDateLabel;
        private System.Windows.Forms.TextBox TypeBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.OpenFileDialog ChooseFileDialog;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.Button UploadConfirmButton;
        private System.Windows.Forms.Label albumName;
        private System.Windows.Forms.TextBox albumTextBox;
        private System.Windows.Forms.TextBox Track_NoBox;
        private System.Windows.Forms.Label Track_NoLabel;
    }
}