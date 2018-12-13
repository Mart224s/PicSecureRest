using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
   internal class TCPClient
   {
       private const int pORT = 8555;
       internal void Start()
       {
           using (TcpClient piClient = new TcpClient("localhost", pORT))
           using (NetworkStream ns = piClient.GetStream())
           using (StreamWriter sw = new StreamWriter(ns))
           using (StreamReader sr = new StreamReader(ns))
           {
               if (piClient.Connected)
               {
                   Console.WriteLine("\nConnected to host...");
               }

               string msg = sr.ReadLine();

               Console.WriteLine($"string in = {msg}");
               Console.ReadLine();
               sw.WriteLine(msg);

               sw.AutoFlush = true;
           }
       }
    }
}
