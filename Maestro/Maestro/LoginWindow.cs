using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    public partial class LoginWindow : Form
    {
        public string LoggedIn;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginConfirmButton_Click(object sender, EventArgs e)
        {
            if (DBAccessor.verifyLoginInfo(UsernameBox.Text, PasswordBox.Text))
            {
                LoggedIn = UsernameBox.Text;
                this.Close();
            }
        }  
    }
}
