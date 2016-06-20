

using System.Configuration;

namespace ChatServer
{
    internal class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var logged = bool.Parse(ConfigurationManager.AppSettings["logged"]);

            var server = new Server(port, logged);
            server.Start();
        }
    }
}
