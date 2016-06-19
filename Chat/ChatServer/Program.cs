
using System.Threading;

namespace ChatServer
{
    class Program
    {
        private static void Main()
        {
            const int port = 2000;
            var server = new Server(port);
            var thread = new Thread(server.Listen);
            thread.Start();
        }
    }
}
