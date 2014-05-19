using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace Maestro
{
    public class MediaManager
    {
        public SshClient ssh;
        public MediaStreamer streamer;

        public void Login(String username)
        {
            //this.Text = "Maestro: Logged in as " + lw.LoggedIn;
            // = lw.LoggedIn;
            if (ssh == null)
            {
                ssh = new SshClient("137.112.128.188", "mpd", "mpd");
                ssh.Connect();
            }
            SshCommand cmd1 = ssh.CreateCommand("cat userconfs/" + username + ".conf");
            String output = cmd1.Execute();
            int index = output.IndexOf("port");
            String port = output.Substring(index + 6, 4);
            int portnum = int.Parse(port);
            SshCommand command = ssh.CreateCommand("mpd userconfs/" + username + ".conf");
            output = command.Execute();
            //            ssh.Disconnect();
            //Thread.Sleep(100);
            byte[] address = { 137, 112, 128, 188 };
            streamer = new MediaStreamer(new System.Net.IPAddress(address), portnum, portnum + 1);
        }

        public void Register(String username)
        {
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
                    DBAccessor.deleteEntry("Users", "Username = " + username);
                    return;
                }
            }
            SshCommand cmd1 = ssh.CreateCommand("cat port");
            String portnum = cmd1.Execute();
            int portnumnum = int.Parse(portnum);
            int streamPort = portnumnum + 1;
            SshCommand command = ssh.CreateCommand("echo 'user \"mpd\"\nport \"" + portnumnum + "\"\nrestore_paused \"yes\"\npid_file \"/run/mpd/" + username + ".pid\"\ndb_file \"/var/lib/mpd/mpd.db\"\nstate_file \"/var/lib/mpd/userstates/" + username + ".mpdstate\"\nplaylist_directory \"/var/lib/mpd/playlists\"\nmusic_directory \"/var/lib/mpd/music\"\naudio_output {\n\ttype\t\"httpd\"\n\tbind_to_address\t\"137.112.128.188\"\n\tname\t\"My HTTP Stream\"\n\tencoder\t\"lame\"\n\tport\t\"" + streamPort + "\" \n\tbitrate\t\"320\"\n\tformat\t\"44100:16:1\"\n}' > userconfs/" + username + ".conf");
            command.Execute();
            //StreamPort = portnumnum;
            portnumnum += 2;
            SshCommand cmd2 = ssh.CreateCommand("echo \"" + portnumnum + "\" > port");
            cmd2.Execute();
            //           ssh.Disconnect();
        }
    }
}
