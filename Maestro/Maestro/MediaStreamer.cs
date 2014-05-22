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
        TcpClient client;

        public MediaStreamer(IPAddress musicServer, int port, int mediaPort)
        {
            //TcpClient client = new TcpClient();
            client = new TcpClient();
            //            TcpClient soundClient = new TcpClient();
//            byte[] address = { 137, 112, 128, 188 };
//            IPAddress musicServer = new IPAddress(address);
            ServerAddress = musicServer;
            ConnectionPort = port;
            client.Connect(musicServer, port);
            MPDControlStream = client.GetStream();
            //InBuffer = new byte[300];
            System.Console.WriteLine(Read());
            MPDControlStream.Close();
            client.Close();
            
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
            while (!Refresh());
            Write("play");
            System.Console.WriteLine(Read());
            Player.controls.play();
            CloseControlStream();
        }

        public void Pause()
        {
            while(!Refresh());

            Write("pause");
            //System.Console.WriteLine(Read());
            Player.controls.pause();
            //System.Console.WriteLine("Made it here");
            CloseControlStream();
        }

        public void Skip()
        {
            while(!Refresh());
            Write("next");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Back()
        {
            while(!Refresh());
            Write("previous");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Seek(String relTime)
        {
            while(!Refresh());
            Write("seekcur " + relTime);
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void SeekPercentage(double percentage, int songLength)
        {
            while(!Refresh());
            int secondsToSeek = (int)Math.Floor(percentage * songLength);
            Write("seekcur " + secondsToSeek);
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Stop()
        {
            while(!Refresh());
            Write("stop");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Add(String filepath)
        {
            while(!Refresh());
            Write("add " + "\"" + filepath + "\"");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Clear()
        {
            while(!Refresh());
            Write("clear");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Update()
        {
            while (!Refresh()) ;
            Write("update");
            System.Console.WriteLine(Read());
            CloseControlStream();
        }

        public void Close()
        {
            Player.close();
        }

        public String[] GetSongInfo()
        {
            while(!Refresh());
            Write("currentsong");
            String temp = Read();
            System.Console.WriteLine(temp);
            return temp.Split('\n');
            CloseControlStream();
        }

        public String[] GetInternalPlaylist()
        {
            while(!Refresh());
            Write("playlist");
            String temp = Read();
            System.Console.WriteLine(temp);

            //foreach (String str in temp.Split('\n'))
            String[] splitString = temp.Split('\n');
            String str = splitString[0];
            if (splitString.Length - 2 <= 0)
                return null;
            String[] toReturn = new String[splitString.Length - 2];
            int i = 0;
            while (str != "OK")
            {
                String[] temp2 = str.Split(':');
                toReturn[int.Parse(temp2[0])] = temp2[2].Substring(1);
                i++;
                str = splitString[i];
            }
            CloseControlStream();
            return toReturn;
        }

        public void Mute()
        {
            while(!Refresh());
            Write("setvol 0");
            System.Console.WriteLine(Read());
            Muted = true;
            CloseControlStream();
        }

        public void Unmute()
        {
            while(!Refresh());
            Write("setvol 100");
            System.Console.WriteLine(Read());
            Muted = false;
            CloseControlStream();
        }

        public String Read()
        {
            byte[] InBuffer = new byte[1000];
            //Refresh();
            try
            {
                MPDControlStream.Read(InBuffer, 0, 1000);
            }
            catch (System.IO.IOException ioex)
            {
                System.Console.WriteLine("Exception caught in Read: attempting to reopen socket...");
                TcpClient client = new TcpClient();
                client.Connect(ServerAddress, ConnectionPort);
                MPDControlStream = client.GetStream();
                MPDControlStream.Read(InBuffer, 0, 1000);
            }
            //CloseControlStream();
            return System.Text.Encoding.Default.GetString(InBuffer);
        }

        public void Write(String command)
        {
            byte[] OutBuffer = Encoding.UTF8.GetBytes(command + "\n");
            //Refresh();
            try
            {
                MPDControlStream.Write(OutBuffer, 0, OutBuffer.Length);
            }
            catch (System.IO.IOException ioex)
            {
                System.Console.WriteLine("Exception caught in Write: attempting to reopen socket...");
                client = new TcpClient();
                client.Connect(ServerAddress, ConnectionPort);
                MPDControlStream = client.GetStream();
                MPDControlStream.Write(OutBuffer, 0, OutBuffer.Length);
            }
            //CloseControlStream();
            System.Console.WriteLine(command);
            Thread.Sleep(100);
        }

        public Boolean Refresh()
        {
            client = new TcpClient();
            try
            {
                client.Connect(ServerAddress, ConnectionPort);
            }
            catch (SocketException sockex)
            {
                if (client.Connected)
                    System.Console.WriteLine("Not connected any more");
                System.Console.WriteLine("Retrying to connect...");
                return false;
            }
            MPDControlStream = client.GetStream();
            Read();
            return true;
        }

        public void CloseControlStream()
        {
            MPDControlStream.Close();
            client.Close();
        }
    }
}
