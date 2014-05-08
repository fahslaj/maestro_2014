using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)(sender);
            String text = cmb.Text;
            Console.WriteLine(text);
            selectedTable = DBAccessor.selectAllTable(text);
            dataGridView1.DataSource = new BindingSource(selectedTable, null);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.ShowDialog();
            this.Text = "Maestro: Logged in as "+lw.LoggedIn;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            AddEntryWindow aew = new AddEntryWindow(selectedTable);
            aew.ShowDialog();
        }

    }
}
 