
using System.Threading;

namespace ChatServer
{
    class Program
    {
        private static void Main()
        {
            const int port = 2000;
            var server = new Server(port);
            server.Start();
        }
    }
}
