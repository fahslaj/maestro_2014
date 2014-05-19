using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        DataTable selectedTable;
        MediaStreamer streamer;
        SshClient ssh;
        String CurrentUser;

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
            this.CurrentUser = lw.LoggedIn;
            if (ssh == null)
            {
                ssh = new SshClient("137.112.128.188", "mpd", "mpd");
                ssh.Connect();
            }
            SshCommand cmd1 = ssh.CreateCommand("cat userconfs/" + lw.LoggedIn + ".conf");
            String output = cmd1.Execute();
            int index = output.IndexOf("port");
            String port = output.Substring(index + 6, 4);
            int portnum = int.Parse(port);
            SshCommand command = ssh.CreateCommand("mpd userconfs/" + lw.LoggedIn + ".conf");
            output = command.Execute();
//            ssh.Disconnect();
            Thread.Sleep(100);
            byte[] address = { 137, 112, 128, 188 };
            streamer = new MediaStreamer(new System.Net.IPAddress(address), portnum, portnum + 1);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
            if (ssh == null)
            {
                try
                {
                    ssh = new SshClient("137.112.128.188", "mpd", "mpd");
                    ssh.Connect();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Problems connecting to music server, try registering later!");
                    DBAccessor.deleteEntry("Users", "Username = " + rw.username);
                    return;
                }
            }
            SshCommand cmd1 = ssh.CreateCommand("cat port");
            String portnum = cmd1.Execute();
            int portnumnum = int.Parse(portnum);
            int streamPort = portnumnum++;
            SshCommand command = ssh.CreateCommand("echo 'user \"mpd\"\nport \"" + portnumnum + "\"\nrestore_paused \"yes\"\npid_file \"/run/mpd/" + CurrentUser + ".pid\"\ndb_file \"/var/lib/mpd/mpd.db\"\nstate_file \"/var/lib/mpd/" + CurrentUser + ".mpdstate\"\nplaylist_directory \"/var/lib/mpd/playlists\"\nmusic_directory \"/var/lib/mpd/music\"\naudio_output {\n\ttype\t\"httpd\"\n\tbind_to_address\t\"137.112.128.188\"\n\tname\t\"My HTTP Stream\"\n\tencoder\t\"lame\"\n\tport\t\"" + streamPort + "\" \n\tbitrate\t\"320\"\n\tformat\t\"44100:16:1\"\n}' > userconfs/" + rw.username + ".conf");
            command.Execute();
            //StreamPort = portnumnum;
            portnumnum += 2;
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

        private void uploadButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void DisplayWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentUser != null)
            {
                streamer.Pause();
                streamer.Close();
                //Handle killing mpd process
                //String output = ssh.CreateCommand("ps aux | grep 'mpd userconfs/" + this.CurrentUser + ".conf' | cut -c 11-15").Execute();
                String output = ssh.CreateCommand("cat /run/mpd/" + CurrentUser + ".pid").Execute();
                ssh.CreateCommand("kill " + output).Execute();

                ssh.Disconnect();
            }
        }

    }
}
 