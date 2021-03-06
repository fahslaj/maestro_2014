﻿using System;
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

            MainMenu menu = new MainMenu();

            mm = menu;

            Application.Run(mm); // change to mm when ready 
        }

        public static void ShowMainMenu()
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
            if (!DBAccessor.verifyLoginInfo(mm.UsernameTextbox.Text, mm.PasswordTextbox.Text))
            {
                MessageBox.Show("Invalid User Information. Try again.");
                return;
            }

            DisplayWindow dw = new DisplayWindow();
            dw.SetUser(mm.UsernameTextbox.Text);
            HideMainMenu();
            dw.ShowDialog();
        }

        public static void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
            if (!rw.confirmed)
                return;
            (new MediaManager()).Register(rw.username);
            MessageBox.Show("Your account was created.");
        }
    }
}
