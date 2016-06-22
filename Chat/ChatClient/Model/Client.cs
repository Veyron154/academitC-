using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ChatClient.View;
using Message;

namespace ChatClient.Model
{
    internal class Client : IClient
    {
        private readonly string _name;
        private readonly string _host;
        private readonly int _port;
        private NetworkStream _stream;
        private readonly TcpClient _client;
        private readonly IChatForm _form;

        public Client(string name, IChatForm form, int port, string host)
        {
            _name = name;
            _host = host;
            _port = port;
            _form = form;
            _client = new TcpClient();
        }

        public void Connect()
        {
            try
            {
                _client.Connect(_host, _port);
                _stream = _client.GetStream();

                SendMessage(_name);

                var thread = new Thread(ReceiveMessage);
                thread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    var formatter = new BinaryFormatter();

                    while (_stream.DataAvailable)
                    {
                        var message = (ChatMessage) formatter.Deserialize(_stream);
                        _form.WriteMessage(message.Data);
                    }
                }
                catch
                {
                    Disconnect();
                    break;
                }
            }
        }

        public void SendMessage(string message)
        {
            var data = new ChatMessage(message);
            var formatter = new BinaryFormatter();
            formatter.Serialize(_stream, data);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
