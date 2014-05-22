﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    class RegisterWindow : Form
    {
        private Label label1;
        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private TextBox RepeatPasswordTextbox;
        private Button RegisterConfirmButton;
        public String username;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        public void ConfirmRegistration(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == RepeatPasswordTextbox.Text)
            {
                username = UsernameTextbox.Text;
                DBAccessor.insertEntry("'" + UsernameTextbox.Text + "'|'" +
                    Math.Abs(PasswordTextbox.Text.GetHashCode() + username.GetHashCode()) + "'", "Users");
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.RepeatPasswordTextbox = new System.Windows.Forms.TextBox();
            this.RegisterConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register New User:";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(15, 29);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(129, 22);
            this.UsernameTextbox.TabIndex = 1;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextbox_KeyPress);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(15, 57);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(129, 22);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextbox_KeyPress);
            // 
            // RepeatPasswordTextbox
            // 
            this.RepeatPasswordTextbox.Location = new System.Drawing.Point(15, 85);
            this.RepeatPasswordTextbox.Name = "RepeatPasswordTextbox";
            this.RepeatPasswordTextbox.Size = new System.Drawing.Size(129, 22);
            this.RepeatPasswordTextbox.TabIndex = 3;
            this.RepeatPasswordTextbox.Text = "Repeat Password";
            this.RepeatPasswordTextbox.UseSystemPasswordChar = true;
            this.RepeatPasswordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RepeatPasswordTextbox_KeyPress);
            // 
            // RegisterConfirmButton
            // 
            this.RegisterConfirmButton.Location = new System.Drawing.Point(15, 114);
            this.RegisterConfirmButton.Name = "RegisterConfirmButton";
            this.RegisterConfirmButton.Size = new System.Drawing.Size(127, 33);
            this.RegisterConfirmButton.TabIndex = 4;
            this.RegisterConfirmButton.Text = "Register";
            this.RegisterConfirmButton.UseVisualStyleBackColor = true;
            // 
            // RegisterWindow
            // 
            this.ClientSize = new System.Drawing.Size(156, 159);
            this.Controls.Add(this.RegisterConfirmButton);
            this.Controls.Add(this.RepeatPasswordTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.label1);
            this.Name = "RegisterWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RepeatPasswordTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
