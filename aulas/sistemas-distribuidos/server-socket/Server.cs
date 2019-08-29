using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                listener.Listen(10);
                Socket handler = listener.Accept();

                byte[] bytes = new byte[1024];

                Console.WriteLine("Socket connected to {0}", localEndPoint.ToString());

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.UTF8.GetBytes("This is a test<EOF>");

                // Send the data through the socket.  
                int bytesSent = handler.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = handler.Receive(bytes);

                Console.WriteLine("Echoed test = {0}",
                    Encoding.UTF8.GetString(bytes, 0, bytesRec));

                var response = Encoding.UTF8.GetBytes(
@"HTTP/1.1 200 OK
Content-Type: text/html
Connection: close

<html>Lorem</html>"
                );

                handler.Send(response);

                // Release the socket.  
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
