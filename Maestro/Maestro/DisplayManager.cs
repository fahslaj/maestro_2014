using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maestro
{
    public static class DisplayManager
    {
        public static MainMenu mm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainMenu mm = new MainMenu();
            DisplayWindow dw = new DisplayWindow();

            Application.Run(dw); // change to mm when ready 
        }

        public static void PromptMainMenu()
        {
            mm.Show();
        }

        public static void HideMainMenu()
        {
            mm.Hide();
        }

        public static void Exit()
        {
            Application.Exit();
        }

        public static void LoginButton_Click(object sender, EventArgs e)
        {

        }

        public static void RegisterButton_Click(object sender, EventArgs e)
        {

        }
    }
}
