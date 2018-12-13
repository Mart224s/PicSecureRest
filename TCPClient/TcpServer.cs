using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    internal class TcpServer
    {
        internal class Server
        {
            private int PORT;

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
                        DoPiClient(socket);
                    });
                }



            }

            private void DoPiClient(TcpClient socket)
            {
               
           
            }
        }
    }
}

