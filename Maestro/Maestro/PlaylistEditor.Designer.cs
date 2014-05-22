namespace Maestro
{
    partial class PlaylistEditor
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
            this.PlaylistNameLabel = new System.Windows.Forms.Label();
            this.PlaylistNameBox = new System.Windows.Forms.TextBox();
            this.CurrentPlaylistDataGrid = new System.Windows.Forms.DataGridView();
            this.AllMediaDataGrid = new System.Windows.Forms.DataGridView();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ShiftUpButton = new System.Windows.Forms.Button();
            this.ShiftDownButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlaylistDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllMediaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaylistNameLabel
            // 
            this.PlaylistNameLabel.AutoSize = true;
            this.PlaylistNameLabel.Location = new System.Drawing.Point(13, 13);
            this.PlaylistNameLabel.Name = "PlaylistNameLabel";
            this.PlaylistNameLabel.Size = new System.Drawing.Size(97, 17);
            this.PlaylistNameLabel.TabIndex = 0;
            this.PlaylistNameLabel.Text = "Playlist Name:";
            // 
            // PlaylistNameBox
            // 
            this.PlaylistNameBox.Location = new System.Drawing.Point(117, 13);
            this.PlaylistNameBox.Name = "PlaylistNameBox";
            this.PlaylistNameBox.ReadOnly = true;
            this.PlaylistNameBox.Size = new System.Drawing.Size(452, 22);
            this.PlaylistNameBox.TabIndex = 1;
            this.PlaylistNameBox.Text = "Insert Name Here";
            // 
            // CurrentPlaylistDataGrid
            // 
            this.CurrentPlaylistDataGrid.AllowUserToAddRows = false;
            this.CurrentPlaylistDataGrid.AllowUserToDeleteRows = false;
            this.CurrentPlaylistDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentPlaylistDataGrid.Location = new System.Drawing.Point(13, 34);
            this.CurrentPlaylistDataGrid.Name = "CurrentPlaylistDataGrid";
            this.CurrentPlaylistDataGrid.ReadOnly = true;
            this.CurrentPlaylistDataGrid.RowTemplate.Height = 24;
            this.CurrentPlaylistDataGrid.Size = new System.Drawing.Size(556, 206);
            this.CurrentPlaylistDataGrid.TabIndex = 2;
            // 
            // AllMediaDataGrid
            // 
            this.AllMediaDataGrid.AllowUserToAddRows = false;
            this.AllMediaDataGrid.AllowUserToDeleteRows = false;
            this.AllMediaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllMediaDataGrid.Location = new System.Drawing.Point(13, 314);
            this.AllMediaDataGrid.Name = "AllMediaDataGrid";
            this.AllMediaDataGrid.ReadOnly = true;
            this.AllMediaDataGrid.RowTemplate.Height = 24;
            this.AllMediaDataGrid.Size = new System.Drawing.Size(556, 206);
            this.AllMediaDataGrid.TabIndex = 3;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(17, 282);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(424, 22);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.Text = "Search All Media";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(447, 282);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(122, 26);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ShiftUpButton
            // 
            this.ShiftUpButton.Location = new System.Drawing.Point(13, 246);
            this.ShiftUpButton.Name = "ShiftUpButton";
            this.ShiftUpButton.Size = new System.Drawing.Size(111, 30);
            this.ShiftUpButton.TabIndex = 6;
            this.ShiftUpButton.Text = "^^ Shift Up ^^";
            this.ShiftUpButton.UseVisualStyleBackColor = true;
            this.ShiftUpButton.Click += new System.EventHandler(this.ShiftUpButton_Click);
            // 
            // ShiftDownButton
            // 
            this.ShiftDownButton.Location = new System.Drawing.Point(130, 246);
            this.ShiftDownButton.Name = "ShiftDownButton";
            this.ShiftDownButton.Size = new System.Drawing.Size(122, 30);
            this.ShiftDownButton.TabIndex = 7;
            this.ShiftDownButton.Text = "vv Shift Down vv";
            this.ShiftDownButton.UseVisualStyleBackColor = true;
            this.ShiftDownButton.Click += new System.EventHandler(this.ShiftDownButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(309, 246);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(68, 30);
            this.RemoveButton.TabIndex = 8;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(383, 246);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(90, 30);
            this.SubmitButton.TabIndex = 9;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(479, 246);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 30);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(258, 246);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(45, 30);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PlaylistEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 532);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ShiftDownButton);
            this.Controls.Add(this.ShiftUpButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.AllMediaDataGrid);
            this.Controls.Add(this.CurrentPlaylistDataGrid);
            this.Controls.Add(this.PlaylistNameBox);
            this.Controls.Add(this.PlaylistNameLabel);
            this.Name = "PlaylistEditor";
            this.Text = "PlaylistEditor";
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlaylistDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllMediaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlaylistNameLabel;
        private System.Windows.Forms.TextBox PlaylistNameBox;
        private System.Windows.Forms.DataGridView CurrentPlaylistDataGrid;
        private System.Windows.Forms.DataGridView AllMediaDataGrid;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ShiftUpButton;
        private System.Windows.Forms.Button ShiftDownButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddButton;
    }
}