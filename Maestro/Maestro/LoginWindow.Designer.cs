namespace Maestro
{
    partial class LoginWindow
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
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LoginConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(13, 13);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(115, 22);
            this.UsernameBox.TabIndex = 0;
            this.UsernameBox.Text = "Username";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 41);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(115, 22);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.Text = "Password";
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // LoginConfirmButton
            // 
            this.LoginConfirmButton.Location = new System.Drawing.Point(13, 70);
            this.LoginConfirmButton.Name = "LoginConfirmButton";
            this.LoginConfirmButton.Size = new System.Drawing.Size(114, 26);
            this.LoginConfirmButton.TabIndex = 2;
            this.LoginConfirmButton.Text = "Login";
            this.LoginConfirmButton.UseVisualStyleBackColor = true;
            this.LoginConfirmButton.Click += new System.EventHandler(this.LoginConfirmButton_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(140, 108);
            this.Controls.Add(this.LoginConfirmButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Name = "LoginWindow";
            this.Text = "LoginWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LoginConfirmButton;

    }
}