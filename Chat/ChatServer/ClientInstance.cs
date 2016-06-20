using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Logger;

namespace ChatServer
{
    internal class ClientInstance
    {
        private readonly TcpClient _client;
        private readonly Server _server;
        private readonly ILogger _logger;

        public string Name { get; private set; }
        public NetworkStream Stream { get; private set; }

        public ClientInstance(TcpClient client, Server server)
        {
            _client = client;
            _server = server;
        }

        public ClientInstance(TcpClient client, Server server, ILogger logger)
        {
            _client = client;
            _server = server;
            _logger = logger;
        }

        public void Start()
        {
            var thread = new Thread(Process);
            thread.Start();
        }

        private void Process()
        {
            try
            {
                Stream = _client.GetStream();
                var message = GetMessage();
                Name = message;

                message = $"({DateTime.Now.ToShortTimeString()}) {Name} вошёл в чат.";
                _server.BroadcastMessage(message);
                _logger.Logging($"({DateTime.Now}) {Name} вошёл в чат.");

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if (message == "GET_CLIENTS")
                        {
                            SendClients();
                            continue;
                        }
                        if (message == "")
                        {
                            message = $"({DateTime.Now.ToShortTimeString()}) {Name} покинул чат.";
                            _server.BroadcastMessage(message);
                            continue;
                        }
                        message = $"({DateTime.Now.ToShortTimeString()}) {Name}: {message}";
                        _server.BroadcastMessage(message);
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _server.RemoveClient(this);
                Disconnect();
            }
        }

        private string GetMessage()
        {
            var message = new byte[128];
            var builder = new StringBuilder();

            do
            {
                var bytes = Stream.Read(message, 0, message.Length);
                builder.Append(Encoding.Unicode.GetString(message, 0, bytes));
            } while (Stream.DataAvailable);

            return builder.ToString();
        }

        private void SendClients()
        {
            var data = Encoding.Unicode.GetBytes(_server.GetClients());
            Stream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            Stream?.Close();
            _client?.Close();
        }
    }
}
