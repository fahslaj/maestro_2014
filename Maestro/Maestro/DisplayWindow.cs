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
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;
        MediaStreamer streamer;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
            byte[] address = {137,112,128,188};
            streamer = new MediaStreamer(new System.Net.IPAddress(address), 6600, 8000);
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

        private void PlaySelectedButton_Click(object sender, EventArgs e)
        {
            PlayMediaWindow pmw = new PlayMediaWindow(streamer);
            int rowNum = GetSelectedRowNumber();

            if (rowNum >= 0)
            {
                DataRow row = selectedTable.Rows[GetSelectedRowNumber()];
                System.Console.WriteLine(rowNum);
            }
            pmw.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private int GetSelectedRowNumber()
        {
            return dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
        }

    }
}
 