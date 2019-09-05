using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_socket
{
    class ClientAndServer
    {
        static Client client = new Client();
        static Server server = new Server();

        public async static Task Start()
        {
            await Task.WhenAll(new Task[] {
                Task.Run(() =>
                {
                    Console.WriteLine("Server starting...");
                    server.Start();
                }),
                Task.Run(() =>
                {
                    Console.WriteLine("Client starting...");
                    client.Start();
                })
            });
        }
    }

    class Client
    {
        UdpClient udpClient = new UdpClient(9090);

        public void Start()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8080);

            byte[] message = Encoding.UTF8.GetBytes("This is a test<EOF>");

            udpClient.Connect(localEndPoint);
            udpClient.Send(message, message.Length);

            Console.WriteLine("Client send = {0}", Encoding.UTF8.GetString(message));
        }
    }

    class Server
    {
        UdpClient udpClient = new UdpClient(8080);

        public void Start()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9090);

            byte[] response = udpClient.Receive(ref localEndPoint);

            Console.WriteLine("Server receive = {0}", Encoding.UTF8.GetString(response));
        }
    }
}
