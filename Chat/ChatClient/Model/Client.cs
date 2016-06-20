using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ChatClient.View;

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

        public Client(string name, IChatForm form, int port)
        {
            _name = name;
            _host = "127.0.0.1";
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

                var data = Encoding.Unicode.GetBytes(_name);
                _stream.Write(data, 0, data.Length);

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
                    var data = new byte[64];
                    var builder = new StringBuilder();

                    while (_stream.DataAvailable)
                    {
                        var bytes = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        _form.WriteMessage(builder.ToString());
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
            var data = Encoding.Unicode.GetBytes(message);
            _stream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
