using System;
using PlainServer;

namespace TcpProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerTcp server = new ServerTcp(7777);

            server.Start();

            Console.ReadLine();
        }
    }
}
