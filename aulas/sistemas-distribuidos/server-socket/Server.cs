using System;
using System.Net;
using System.Net.Sockets;

namespace server_socket
{
    class Server
    {
        public void Start()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8080);
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.WriteLine("Start to run");
                listener.Bind(localEndPoint);
                listener.Listen(100);
                listener.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
