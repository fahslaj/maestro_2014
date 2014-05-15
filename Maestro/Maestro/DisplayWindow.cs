using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;
        MediaStreamer streamer;
        SshClient ssh;

        public DisplayWindow()
        {
            InitializeComponent();
            this.Text = "Maestro: Guest User";
//            byte[] address = { 137, 112, 128, 188 };
//            streamer = new MediaStreamer(new System.Net.IPAddress(address), 6600, 8000);
            
//            streamer.Play();
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
            if (ssh != null)
            {
                ssh = new SshClient("137.112.128.188", "mpd", "mpd");
                ssh.Connect();
            }
            SshCommand cmd1 = ssh.CreateCommand("cat userconfs/" + lw.LoggedIn + ".conf");
            String output = cmd1.Execute();
            int index = output.IndexOf("port");
            String port = output.Substring(index + 6, 4);
            int portnum = int.Parse(port);
            SshCommand command = ssh.CreateCommand("mpd userconfs/" + lw.LoggedIn + ".conf &");
            command.Execute();
//            ssh.Disconnect();
            byte[] address = { 137, 112, 128, 188 };
            streamer = new MediaStreamer(new System.Net.IPAddress(address), 6600, portnum);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
            //if (ssh != null)
            //{
                ssh = new SshClient("137.112.128.188", "mpd", "mpd");
                ssh.Connect();
            //}
            SshCommand cmd1 = ssh.CreateCommand("cat port");
            String portnum = cmd1.Execute();
            int portnumnum = int.Parse(portnum);
            SshCommand command = ssh.CreateCommand("echo 'user \"mpd\"\nrestore_paused \"yes\"\npid_file \"/run/mpd/mpd.pid\"\ndb_file \"/var/lib/mpd/mpd.db\"\nstate_file \"/var/lib/mpd/mpdstate\"\nplaylist_directory \"/var/lib/mpd/playlists\"\nmusic_directory \"/var/lib/mpd/music\"\naudio_output {\n\ttype\t\"httpd\"\n\tbind_to_address\t\"137.112.128.188\"\n\tname\t\"My HTTP Stream\"\n\tencoder\t\"lame\"\n\tport\t\"" + portnum + "\"\n\tbitrate\t\"320\"\n\tformat\t\"44100:16:1\"\n}' > userconfs/" + rw.username + ".conf");
            command.Execute();
            //StreamPort = portnumnum;
            portnumnum++;
            SshCommand cmd2 = ssh.CreateCommand("echo \"" + portnumnum + "\" > port");
            cmd2.Execute();
 //           ssh.Disconnect();
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            AddEntryWindow aew = new AddEntryWindow(selectedTable);
            aew.ShowDialog();
        }

        private void PlaySelectedButton_Click(object sender, EventArgs e)
        {
            PlayMediaWindow pmw = new PlayMediaWindow(streamer);
            DataRow row = GetSelectedRow();
            pmw.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private DataRow GetSelectedRow()
        {
            //Get the context.
            BindingContext context = dataGridView1.BindingContext;

            // Get the currency manager.
            BindingManagerBase manager = context[selectedTable];

            // Get the current row view.
            DataRowView rowView = (DataRowView) manager.Current;

            // Get the row.
            DataRow row = rowView.Row;

            Console.WriteLine(row.ItemArray[0]);
            return row;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            string filepath = "";
            if (UploadFileDialog.ShowDialog() == DialogResult.OK)
                filepath = UploadFileDialog.FileName;
            Console.WriteLine(filepath);
            SftpClient sftpClient = new SftpClient("137.112.128.188", "mpd", "mpd");
            sftpClient.Connect();
            char[] split = {'\\', '\\'};
            String[] path = filepath.Split(split);
            System.IO.FileStream file = new System.IO.FileStream(filepath, System.IO.FileMode.Open);
            try
            {
                sftpClient.UploadFile(file, "/var/lib/mpd/music/" + path[path.Length - 1]);
            }
            catch (Renci.SshNet.Common.SshException sshe)
            {
                System.Console.WriteLine(sshe.Message);
            }
            sftpClient.Disconnect();
        }

    }
}
 