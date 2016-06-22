using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Logger;
using Message;

namespace ChatServer
{
    internal class ClientInstance
    {
        private readonly TcpClient _client;
        private readonly Server _server;
        private readonly ILogger _logger;
        private NetworkStream _stream;
        private readonly BinaryFormatter _formatter;

        public string Name { get; private set; }
        public string Id { get; }
        
        public ClientInstance(TcpClient client, Server server, ILogger logger)
        {
            _client = client;
            _server = server;
            _logger = logger;
            _formatter = new BinaryFormatter();
            Id = Guid.NewGuid().ToString();
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
                _stream = _client.GetStream();
                var message = GetMessage();
                Name = message;

                message = $"({DateTime.Now.ToShortTimeString()}) {Name} вошёл в чат.";
                _server.BroadcastMessage(message, Id);
                SendMessage("Вы вошли в чат.");
                _logger.Log($"({DateTime.Now}) {Name} вошёл в чат.");

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if (message == "GET_CLIENTS")
                        {
                            SendMessage(_server.GetClients());
                            continue;
                        }
                        message = $"({DateTime.Now.ToShortTimeString()}) {Name}: {message}";
                        _server.BroadcastMessage(message, Id);
                        SendMessage(message);
                    }
                    catch
                    {
                        message = $"({DateTime.Now.ToShortTimeString()}) {Name} покинул чат.";
                        _server.BroadcastMessage(message, Id);
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
            var chatMessage = (ChatMessage) _formatter.Deserialize(_stream);
            var message = chatMessage.Data;
            return message;
        }

        public void SendMessage(string message)
        {
            _formatter.Serialize(_stream, new ChatMessage(message));
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
