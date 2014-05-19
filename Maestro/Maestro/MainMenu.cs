using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.ClientSize = new System.Drawing.Size(458, 668);
            this.Name = "MainMenu";
            this.Text = "Maestro";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
