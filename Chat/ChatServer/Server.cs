using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Logger;

namespace ChatServer
{
    internal class Server
    {
        private TcpListener _listener;
        private readonly List<ClientInstance> _clients;
        private readonly int _port;
        private readonly bool _logged;
        private readonly ILogger _logger;

        public Server(int port, bool logged)
        {
            _port = port;
            _clients = new List<ClientInstance>();
            _logged = logged;
            if (logged)
            {
                _logger = new FileLogger("Log.txt");
            }
            else
            {
                _logger = new NullLogger();
            }
        }

        public void Start()
        {
            var thread = new Thread(Listen);
            thread.Start();
        }

        private void Listen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, _port);
                _listener.Start();
                Console.WriteLine("Сервер запущен");
                _logger.Log($"({DateTime.Now}) Сервер запущен.");

                while (true)
                {
                    var tcpClient = _listener.AcceptTcpClient();
                    var clientInstance = new ClientInstance(tcpClient, this, _logger);
                    _clients.Add(clientInstance);
                    clientInstance.Start();
                }
            }
            catch
            {
                Disconnect();
            }
        }

        public void BroadcastMessage(string message)
        {
            var data = Encoding.Unicode.GetBytes(message);

            foreach (var client in _clients)
            {
                client.Stream.Write(data, 0, data.Length);
            }
        }

        public void RemoveClient(ClientInstance client)
        {
            _logger.Log($"({DateTime.Now}) {client.Name} покинул чат.");
            _clients.Remove(client);
        }

        public string GetClients()
        {
            return "Список участников:" + Environment.NewLine + string.Join(Environment.NewLine, 
                _clients.Select(c => c.Name));
        }

        private void Disconnect()
        {
            _listener.Stop();
            foreach (var client in _clients)
            {
                client.Disconnect();
            }
            Environment.Exit(0);
        }
    }
}
