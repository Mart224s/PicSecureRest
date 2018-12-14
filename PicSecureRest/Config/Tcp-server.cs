using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PlainServer
{
    internal class Server
    {
        private int PORT;

        // integer der bruges til id på billeder der modtages
        private static int filenNum = 0;

        public Server(int port)
        {
            this.PORT = port;
        }

        public void Start()
        {
            TcpListener thisServer = new TcpListener(IPAddress.Any, PORT);


            thisServer.Start();

            while (true)
            {
                TcpClient socket = thisServer.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(socket);
                });
            }
        }

        private void DoClient(TcpClient socket)
        {
            //Starter et stream på det givne netværk
            NetworkStream clientStream = socket.GetStream();

            // Filestream der laver en ny film på den angivet sti
            FileStream fs =
                (File.Create(
                    @"C:\Users\mahdi\Sync\DATAMATIKER\3 Semester\3SemesterPROJEKT\PicSecureRest\imgFiles\imgFile" +
                    filenNum++ + ".jpg"));

            int count;

            // Buffer til at modtage billeder. Et array af bytes, der kan tage 2048 bytes af gangen
            byte[] imgBuffer = new byte[2048];

            while (socket.Connected)
            {
                // variabel der tæller antal bytes. Tager b.la. buffer som parameter
                count = clientStream.Read(imgBuffer, 0, 2000);

                // Variabel af Filestream, skriver bytes ud, så man ender med at have et billede. 
                fs.Write(imgBuffer, 0, count);
            }

            fs.Close();
        }
    }
}