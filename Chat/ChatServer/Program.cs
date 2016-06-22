

using System.Configuration;
using Logger;

namespace ChatServer
{
    internal class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var logged = bool.Parse(ConfigurationManager.AppSettings["logged"]);
            ILogger logger;

            if (logged)
            {
                logger = new FileLogger("log.txt");
            }
            else
            {
                logger = new NullObjectLogger();
            }

            var server = new Server(port, logger);
            server.Start();
        }
    }
}
