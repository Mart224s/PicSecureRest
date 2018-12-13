using System;

namespace TCPClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
           TCPClient piClient = new TCPClient();
           
           piClient.Start();

           Console.ReadLine(); 
        }
    }
}
