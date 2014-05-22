using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    public class MainMenu : Form
    {
        private PictureBox pictureBox1;
        public TextBox UsernameTextbox;
        public TextBox PasswordTextbox;
        private Button LoginButton;
        private Button RegisterButton;
    
        public MainMenu()
        {
            InitializeComponent();
            this.LoginButton.Click += new System.EventHandler(DisplayManager.LoginButton_Click);
            this.RegisterButton.Click += new System.EventHandler(DisplayManager.RegisterButton_Click);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 432);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(235, 300);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(211, 22);
            this.UsernameTextbox.TabIndex = 1;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UsernameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextbox_KeyPress);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(235, 328);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(211, 22);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextbox_KeyPress);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(235, 357);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(211, 27);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(235, 390);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(211, 27);
            this.RegisterButton.TabIndex = 4;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.ClientSize = new System.Drawing.Size(458, 425);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 470);
            this.MinimumSize = new System.Drawing.Size(476, 470);
            this.Name = "MainMenu";
            this.Text = "Maestro";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void UsernameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PasswordTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
