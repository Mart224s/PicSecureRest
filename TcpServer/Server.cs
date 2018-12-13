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
        private static int filenum = 0; 

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
            NetworkStream clientStream = socket.GetStream();
            FileStream fs = (File.Create(@"C:\Users\mahdi\Sync\DATAMATIKER\3 Semester\3SemesterPROJEKT\PicSecureRest\imgFiles\imgFile" + filenum++ + ".jpg"));

            int count;

            byte[] imgBytes = new byte[2048];

            while (socket.Connected)
            {
                count = clientStream.Read(imgBytes, 0, 2000);

                fs.Write(imgBytes,0, count);
            }
            fs.Close();            

        }
    }
}