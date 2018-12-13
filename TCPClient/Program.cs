using System;

namespace TCPClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
           TcpServer piServer = new TcpServer.TcpServer();
           
           piClient.Start();

           Console.ReadLine(); 
        }
    }
}
