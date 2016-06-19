using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ChatClient.View;

namespace ChatClient.Model
{
    internal class Client : IClient
    {
        private readonly string name;
        private readonly string host;
        private readonly int port;
        private NetworkStream stream;
        private readonly TcpClient client;
        private readonly IChatForm form;

        public Client(string name, IChatForm form)
        {
            this.name = name;
            host = "127.0.0.1";
            port = 2000;
            this.form = form;
            client = new TcpClient();
        }

        public void Connect()
        {
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                var data = Encoding.Unicode.GetBytes(name);
                stream.Write(data, 0, data.Length);

                var thread = new Thread(ReceiveMessage);
                thread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        public void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    var data = new byte[64];
                    var builder = new StringBuilder();

                    while (stream.DataAvailable)
                    {
                        var bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        form.WriteMessage(builder.ToString());
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
            stream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }
    }
}
