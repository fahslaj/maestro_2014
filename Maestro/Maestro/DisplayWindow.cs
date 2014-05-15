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
using System.Net.Sockets;
using System.Net;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
            TcpClient client = new TcpClient();
            byte[] address = {137, 112, 128, 188};
            IPAddress musicServer = new IPAddress(address);
            client.Connect(musicServer, 6600);
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[300];
            stream.Read(buffer, 0, 300);
            string text = System.Text.Encoding.Default.GetString(buffer);
            System.Console.WriteLine(text);
            buffer = Encoding.UTF8.GetBytes("status\n");
            stream.Write(buffer, 0, buffer.Length);
            buffer = new byte[300];
            stream.Read(buffer, 0, 300);
            text = System.Text.Encoding.Default.GetString(buffer);
            System.Console.WriteLine(text);
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
 