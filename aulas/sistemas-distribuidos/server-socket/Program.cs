using System;

namespace server_socket
{
    class Program
    {
        static Server server = new Server();

        static void Main(string[] args)
        {
            server.Start();
            Console.WriteLine("\nPress ENTER to continue...");
        }
    }
}
