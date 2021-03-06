﻿namespace Maestro
{
    partial class DisplayWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayWindow));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ImageDisplayerBox = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsubscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followedPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAllPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unFollowPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCurrentPlayQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCurrentPlayQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myReviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchReviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BackButton = new System.Windows.Forms.Button();
            this.SkipButton = new System.Windows.Forms.Button();
            this.MuteUnmuteButton = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.PlayNext = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayerBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(385, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(701, 393);
            this.dataGridView1.TabIndex = 0;
            // 
            // ImageDisplayerBox
            // 
            this.ImageDisplayerBox.Image = ((System.Drawing.Image)(resources.GetObject("ImageDisplayerBox.Image")));
            this.ImageDisplayerBox.Location = new System.Drawing.Point(2, 30);
            this.ImageDisplayerBox.Name = "ImageDisplayerBox";
            this.ImageDisplayerBox.Size = new System.Drawing.Size(377, 393);
            this.ImageDisplayerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageDisplayerBox.TabIndex = 12;
            this.ImageDisplayerBox.TabStop = false;
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(125, 371);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(40, 40);
            this.PlayButton.TabIndex = 13;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(171, 371);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(40, 40);
            this.PauseButton.TabIndex = 14;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mediaToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.reviewToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.unsubscribeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // unsubscribeToolStripMenuItem
            // 
            this.unsubscribeToolStripMenuItem.Name = "unsubscribeToolStripMenuItem";
            this.unsubscribeToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.unsubscribeToolStripMenuItem.Text = "Unsubscribe";
            this.unsubscribeToolStripMenuItem.Click += new System.EventHandler(this.unsubscribeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mediaToolStripMenuItem
            // 
            this.mediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadMediaToolStripMenuItem,
            this.favoritesToolStripMenuItem,
            this.addFavoriteToolStripMenuItem,
            this.removeFavoriteToolStripMenuItem,
            this.searchMediaToolStripMenuItem,
            this.searchSongsToolStripMenuItem});
            this.mediaToolStripMenuItem.Name = "mediaToolStripMenuItem";
            this.mediaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.mediaToolStripMenuItem.Text = "Media";
            // 
            // uploadMediaToolStripMenuItem
            // 
            this.uploadMediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songToolStripMenuItem});
            this.uploadMediaToolStripMenuItem.Name = "uploadMediaToolStripMenuItem";
            this.uploadMediaToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.uploadMediaToolStripMenuItem.Text = "Upload Media";
            // 
            // songToolStripMenuItem
            // 
            this.songToolStripMenuItem.Name = "songToolStripMenuItem";
            this.songToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.songToolStripMenuItem.Text = "Song";
            this.songToolStripMenuItem.Click += new System.EventHandler(this.songToolStripMenuItem_Click);
            // 
            // favoritesToolStripMenuItem
            // 
            this.favoritesToolStripMenuItem.Name = "favoritesToolStripMenuItem";
            this.favoritesToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.favoritesToolStripMenuItem.Text = "My Favorites";
            this.favoritesToolStripMenuItem.Click += new System.EventHandler(this.getFavoritesToolStripMenuItem_Click);
            // 
            // addFavoriteToolStripMenuItem
            // 
            this.addFavoriteToolStripMenuItem.Name = "addFavoriteToolStripMenuItem";
            this.addFavoriteToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.addFavoriteToolStripMenuItem.Text = "Add Favorite";
            this.addFavoriteToolStripMenuItem.Click += new System.EventHandler(this.addFavoriteToolStripMenuItem_Click);
            // 
            // removeFavoriteToolStripMenuItem
            // 
            this.removeFavoriteToolStripMenuItem.Name = "removeFavoriteToolStripMenuItem";
            this.removeFavoriteToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.removeFavoriteToolStripMenuItem.Text = "Remove Favorite";
            this.removeFavoriteToolStripMenuItem.Click += new System.EventHandler(this.removeFavoriteToolStripMenuItem_Click);
            // 
            // searchMediaToolStripMenuItem
            // 
            this.searchMediaToolStripMenuItem.Name = "searchMediaToolStripMenuItem";
            this.searchMediaToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.searchMediaToolStripMenuItem.Text = "Search Media";
            this.searchMediaToolStripMenuItem.Click += new System.EventHandler(this.searchMediaToolStripMenuItem_Click);
            // 
            // searchSongsToolStripMenuItem
            // 
            this.searchSongsToolStripMenuItem.Name = "searchSongsToolStripMenuItem";
            this.searchSongsToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.searchSongsToolStripMenuItem.Text = "Search Songs";
            this.searchSongsToolStripMenuItem.Click += new System.EventHandler(this.searchSongsToolStripMenuItem_Click);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPlaylistToolStripMenuItem,
            this.editPlaylistToolStripMenuItem,
            this.myPlaylistsToolStripMenuItem,
            this.followedPlaylistsToolStripMenuItem,
            this.searchAllPlaylistsToolStripMenuItem,
            this.selectedPlaylistToolStripMenuItem,
            this.showCurrentPlayQueueToolStripMenuItem,
            this.clearCurrentPlayQueueToolStripMenuItem});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // createNewPlaylistToolStripMenuItem
            // 
            this.createNewPlaylistToolStripMenuItem.Name = "createNewPlaylistToolStripMenuItem";
            this.createNewPlaylistToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.createNewPlaylistToolStripMenuItem.Text = "Create New Playlist";
            this.createNewPlaylistToolStripMenuItem.Click += new System.EventHandler(this.createNewPlaylistToolStripMenuItem_Click);
            // 
            // editPlaylistToolStripMenuItem
            // 
            this.editPlaylistToolStripMenuItem.Name = "editPlaylistToolStripMenuItem";
            this.editPlaylistToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.editPlaylistToolStripMenuItem.Text = "Edit Playlist";
            this.editPlaylistToolStripMenuItem.Click += new System.EventHandler(this.editPlaylistToolStripMenuItem_Click);
            // 
            // myPlaylistsToolStripMenuItem
            // 
            this.myPlaylistsToolStripMenuItem.Name = "myPlaylistsToolStripMenuItem";
            this.myPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.myPlaylistsToolStripMenuItem.Text = "My Playlists";
            this.myPlaylistsToolStripMenuItem.Click += new System.EventHandler(this.myPlaylistsToolStripMenuItem_Click);
            // 
            // followedPlaylistsToolStripMenuItem
            // 
            this.followedPlaylistsToolStripMenuItem.Name = "followedPlaylistsToolStripMenuItem";
            this.followedPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.followedPlaylistsToolStripMenuItem.Text = "Followed Playlists";
            this.followedPlaylistsToolStripMenuItem.Click += new System.EventHandler(this.followedPlaylistsToolStripMenuItem_Click);
            // 
            // searchAllPlaylistsToolStripMenuItem
            // 
            this.searchAllPlaylistsToolStripMenuItem.Name = "searchAllPlaylistsToolStripMenuItem";
            this.searchAllPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.searchAllPlaylistsToolStripMenuItem.Text = "Search All Playlists";
            this.searchAllPlaylistsToolStripMenuItem.Click += new System.EventHandler(this.searchAllPlaylistsToolStripMenuItem_Click);
            // 
            // selectedPlaylistToolStripMenuItem
            // 
            this.selectedPlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandPlaylistToolStripMenuItem,
            this.followPlaylistToolStripMenuItem,
            this.unFollowPlaylistToolStripMenuItem,
            this.addToQueueToolStripMenuItem});
            this.selectedPlaylistToolStripMenuItem.Name = "selectedPlaylistToolStripMenuItem";
            this.selectedPlaylistToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.selectedPlaylistToolStripMenuItem.Text = "Selected Playlist";
            // 
            // expandPlaylistToolStripMenuItem
            // 
            this.expandPlaylistToolStripMenuItem.Name = "expandPlaylistToolStripMenuItem";
            this.expandPlaylistToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.expandPlaylistToolStripMenuItem.Text = "Expand Playlist";
            this.expandPlaylistToolStripMenuItem.Click += new System.EventHandler(this.expandPlaylistToolStripMenuItem_Click_1);
            // 
            // followPlaylistToolStripMenuItem
            // 
            this.followPlaylistToolStripMenuItem.Name = "followPlaylistToolStripMenuItem";
            this.followPlaylistToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.followPlaylistToolStripMenuItem.Text = "Follow Playlist";
            this.followPlaylistToolStripMenuItem.Click += new System.EventHandler(this.followPlaylistToolStripMenuItem_Click);
            // 
            // unFollowPlaylistToolStripMenuItem
            // 
            this.unFollowPlaylistToolStripMenuItem.Name = "unFollowPlaylistToolStripMenuItem";
            this.unFollowPlaylistToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.unFollowPlaylistToolStripMenuItem.Text = "UnFollow Playlist";
            this.unFollowPlaylistToolStripMenuItem.Click += new System.EventHandler(this.unFollowPlaylistToolStripMenuItem_Click);
            // 
            // addToQueueToolStripMenuItem
            // 
            this.addToQueueToolStripMenuItem.Name = "addToQueueToolStripMenuItem";
            this.addToQueueToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.addToQueueToolStripMenuItem.Text = "Add All To Queue";
            this.addToQueueToolStripMenuItem.Click += new System.EventHandler(this.addToQueueToolStripMenuItem_Click);
            // 
            // showCurrentPlayQueueToolStripMenuItem
            // 
            this.showCurrentPlayQueueToolStripMenuItem.Name = "showCurrentPlayQueueToolStripMenuItem";
            this.showCurrentPlayQueueToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.showCurrentPlayQueueToolStripMenuItem.Text = "Show Current Play Queue";
            this.showCurrentPlayQueueToolStripMenuItem.Click += new System.EventHandler(this.showCurrentPlayQueueToolStripMenuItem_Click);
            // 
            // clearCurrentPlayQueueToolStripMenuItem
            // 
            this.clearCurrentPlayQueueToolStripMenuItem.Name = "clearCurrentPlayQueueToolStripMenuItem";
            this.clearCurrentPlayQueueToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.clearCurrentPlayQueueToolStripMenuItem.Text = "Clear Current Play Queue";
            this.clearCurrentPlayQueueToolStripMenuItem.Click += new System.EventHandler(this.clearCurrentPlayQueueToolStripMenuItem_Click);
            // 
            // reviewToolStripMenuItem
            // 
            this.reviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeReviewToolStripMenuItem,
            this.myReviewsToolStripMenuItem,
            this.searchReviewsToolStripMenuItem,
            this.showReviewToolStripMenuItem});
            this.reviewToolStripMenuItem.Name = "reviewToolStripMenuItem";
            this.reviewToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reviewToolStripMenuItem.Text = "Review";
            // 
            // writeReviewToolStripMenuItem
            // 
            this.writeReviewToolStripMenuItem.Name = "writeReviewToolStripMenuItem";
            this.writeReviewToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.writeReviewToolStripMenuItem.Text = "Write Review";
            this.writeReviewToolStripMenuItem.Click += new System.EventHandler(this.writeReviewToolStripMenuItem_Click);
            // 
            // myReviewsToolStripMenuItem
            // 
            this.myReviewsToolStripMenuItem.Name = "myReviewsToolStripMenuItem";
            this.myReviewsToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.myReviewsToolStripMenuItem.Text = "My Reviews";
            this.myReviewsToolStripMenuItem.Click += new System.EventHandler(this.myReviewsToolStripMenuItem_Click);
            // 
            // searchReviewsToolStripMenuItem
            // 
            this.searchReviewsToolStripMenuItem.Name = "searchReviewsToolStripMenuItem";
            this.searchReviewsToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.searchReviewsToolStripMenuItem.Text = "Search Reviews";
            this.searchReviewsToolStripMenuItem.Click += new System.EventHandler(this.searchReviewsToolStripMenuItem_Click);
            // 
            // showReviewToolStripMenuItem
            // 
            this.showReviewToolStripMenuItem.Name = "showReviewToolStripMenuItem";
            this.showReviewToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.showReviewToolStripMenuItem.Text = "Show Review";
            this.showReviewToolStripMenuItem.Click += new System.EventHandler(this.showReviewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 24);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(79, 371);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(40, 40);
            this.BackButton.TabIndex = 16;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SkipButton
            // 
            this.SkipButton.BackColor = System.Drawing.Color.Transparent;
            this.SkipButton.Image = ((System.Drawing.Image)(resources.GetObject("SkipButton.Image")));
            this.SkipButton.Location = new System.Drawing.Point(217, 371);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(40, 40);
            this.SkipButton.TabIndex = 17;
            this.SkipButton.UseVisualStyleBackColor = true;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // MuteUnmuteButton
            // 
            this.MuteUnmuteButton.BackColor = System.Drawing.Color.Transparent;
            this.MuteUnmuteButton.Image = ((System.Drawing.Image)(resources.GetObject("MuteUnmuteButton.Image")));
            this.MuteUnmuteButton.Location = new System.Drawing.Point(73, 371);
            this.MuteUnmuteButton.Name = "MuteUnmuteButton";
            this.MuteUnmuteButton.Size = new System.Drawing.Size(40, 40);
            this.MuteUnmuteButton.TabIndex = 18;
            this.MuteUnmuteButton.UseVisualStyleBackColor = true;
            this.MuteUnmuteButton.Click += new System.EventHandler(this.MuteUnmuteButton_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(385, 3);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(543, 22);
            this.SearchBar.TabIndex = 18;
            this.SearchBar.Text = "Search";
            this.SearchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBar_KeyPress);
            // 
            // PlayNext
            // 
            this.PlayNext.Image = ((System.Drawing.Image)(resources.GetObject("PlayNext.Image")));
            this.PlayNext.Location = new System.Drawing.Point(263, 371);
            this.PlayNext.Name = "PlayNext";
            this.PlayNext.Size = new System.Drawing.Size(40, 40);
            this.PlayNext.TabIndex = 19;
            this.PlayNext.UseVisualStyleBackColor = true;
            this.PlayNext.Click += new System.EventHandler(this.PlayNext_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(934, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(152, 25);
            this.SearchButton.TabIndex = 20;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DisplayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 423);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.PlayNext);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ImageDisplayerBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1107, 468);
            this.MinimumSize = new System.Drawing.Size(1107, 468);
            this.Name = "DisplayWindow";
            this.Text = "Table Display";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DisplayWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayerBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox ImageDisplayerBox;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeReviewToolStripMenuItem;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myPlaylistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAllPlaylistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myReviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchReviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMediaToolStripMenuItem;
        private System.Windows.Forms.Button MuteUnmuteButton;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.ToolStripMenuItem showCurrentPlayQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFavoriteToolStripMenuItem;
        private System.Windows.Forms.Button PlayNext;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ToolStripMenuItem selectedPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsubscribeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCurrentPlayQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unFollowPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followedPlaylistsToolStripMenuItem;
    }
}

