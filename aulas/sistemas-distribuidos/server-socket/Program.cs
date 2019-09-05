using System;
using System.Threading.Tasks;

namespace server_socket
{
    class Program
    {
        static Socket1 socket1 = new Socket1();

        static void Main(string[] args)
        {
            Console.WriteLine("Started");

            ClientAndServer.Start().Wait();

            Console.WriteLine("Finished");
        }
    }
}
