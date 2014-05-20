using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Maestro
{
    public class MediaStreamer
    {
        NetworkStream MPDControlStream;
        WMPLib.WindowsMediaPlayer Player;
        IPAddress ServerAddress;
        int ConnectionPort;
        public Boolean Muted;

        public MediaStreamer(IPAddress musicServer, int port, int mediaPort)
        {
            TcpClient client = new TcpClient();
            //            TcpClient soundClient = new TcpClient();
//            byte[] address = { 137, 112, 128, 188 };
//            IPAddress musicServer = new IPAddress(address);
            ServerAddress = musicServer;
            ConnectionPort = port;
            client.Connect(musicServer, port);
            MPDControlStream = client.GetStream();
            //InBuffer = new byte[300];
            System.Console.WriteLine(Read());
            
            //            soundClient.Connect(musicServer, 8000);
            //            NetworkStream mediaStream = soundClient.GetStream();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(mediaStream);
            //System.Windows.Media.MediaPlayer mp = new MediaPlayer(mediaStream);
            //player.Play();
            Player = new WMPLib.WindowsMediaPlayer();

            Player.URL = "http://"+ musicServer + ":" + mediaPort;
        }

        public void Play()
        {
            Write("play");
            System.Console.WriteLine(Read());
            Player.controls.play();
        }

        public void Pause()
        {
            Write("pause");
            System.Console.WriteLine(Read());
            Player.controls.pause();
        }

        public void Skip()
        {
            Write("next");
            System.Console.WriteLine(Read());
        }

        public void Back()
        {
            Write("previous");
            System.Console.WriteLine(Read());
        }

        public void Seek(String relTime)
        {
            Write("seekcur " + relTime);
            System.Console.WriteLine(Read());
        }

        public void SeekPercentage(double percentage, int songLength)
        {
            int secondsToSeek = (int)Math.Floor(percentage * songLength);
            Write("seekcur " + secondsToSeek);
            System.Console.WriteLine(Read());
        }

        public void Stop()
        {
            Write("stop");
            System.Console.WriteLine(Read());
        }

        public void Add(String filepath)
        {
            Write("add " + filepath);
            System.Console.WriteLine(Read());
        }

        public void Clear()
        {
            Write("clear");
            System.Console.WriteLine(Read());
        }

        public void Close()
        {
            Player.close();
        }

        public String[] GetSongInfo()
        {
            Write("currentsong");
            String temp = Read();
            System.Console.WriteLine(temp);
            return temp.Split('\n');
        }

        public String[] GetInternalPlaylist()
        {
            Write("playlist");
            String temp = Read();
            System.Console.WriteLine(temp);
            return temp.Split(':');
        }

        public void Mute()
        {
            Write("setvol 0");
            System.Console.WriteLine(Read());
        }

        public void Unmute()
        {
            Write("setvol 100");
            System.Console.WriteLine(Read());
        }

        public String Read()
        {
            byte[] InBuffer = new byte[300];
            try
            {
                MPDControlStream.Read(InBuffer, 0, 300);
            }
            catch (System.IO.IOException ioex)
            {
                System.Console.WriteLine("Exception caught in Read: attempting to reopen socket...");
                TcpClient client = new TcpClient();
                client.Connect(ServerAddress, ConnectionPort);
                MPDControlStream = client.GetStream();
                MPDControlStream.Read(InBuffer, 0, 300);
            }
            return System.Text.Encoding.Default.GetString(InBuffer);
        }

        public void Write(String command)
        {
            byte[] OutBuffer = Encoding.UTF8.GetBytes(command + "\n");
            try
            {
                MPDControlStream.Write(OutBuffer, 0, OutBuffer.Length);
            }
            catch (System.IO.IOException ioex)
            {
                System.Console.WriteLine("Exception caught in Write: attempting to reopen socket...");
                TcpClient client = new TcpClient();
                client.Connect(ServerAddress, ConnectionPort);
                MPDControlStream = client.GetStream();
                MPDControlStream.Write(OutBuffer, 0, OutBuffer.Length);
            }
            System.Console.WriteLine(command);
            Thread.Sleep(100);
        }
    }
}
