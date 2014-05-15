using System;
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button RegisterConfirmButton;
        public String username;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        public void ConfirmRegistration(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                DBAccessor.insertEntry("'" + textBox1.Text + "'|'" + textBox2.Text + "'|'" + textBox3.Text + "'", "Users");
                username = textBox1.Text;
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Username";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Password";
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(129, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Repeat Password";
            this.textBox3.UseSystemPasswordChar = true;
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
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "RegisterWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
