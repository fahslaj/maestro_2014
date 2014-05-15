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
        byte[] InBuffer;
        byte[] OutBuffer;

        public MediaStreamer(IPAddress musicServer, int port, int mediaPort)
        {
            TcpClient client = new TcpClient();
            //            TcpClient soundClient = new TcpClient();
//            byte[] address = { 137, 112, 128, 188 };
//            IPAddress musicServer = new IPAddress(address);
            client.Connect(musicServer, port);
            MPDControlStream = client.GetStream();
            InBuffer = new byte[300];
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

        public void FastForward()
        {
            Write("next");
            System.Console.WriteLine(Read());
        }

        public void Rewind()
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

        public String Read()
        {
            MPDControlStream.Read(InBuffer, 0, 300);
            return System.Text.Encoding.Default.GetString(InBuffer);
        }

        public void Write(String command)
        {
            OutBuffer = Encoding.UTF8.GetBytes(command + "\n");
            MPDControlStream.Write(OutBuffer, 0, OutBuffer.Length);
            Thread.Sleep(100);
        }
    }
}
