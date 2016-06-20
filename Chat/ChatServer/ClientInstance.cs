using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    internal class ClientInstance
    {
        public string Name { get; private set; }
        public NetworkStream Stream { get; private set; }
        private readonly TcpClient client;
        private readonly Server server;

        public ClientInstance(TcpClient client, Server server)
        {
            this.client = client;
            this.server = server;
        }

        public void Start()
        {
            var thread = new Thread(Process);
            thread.Start();
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                var message = GetMessage();
                Name = message;

                message = $"({DateTime.Now.ToShortTimeString()}) {Name} вошёл в чат.";
                server.BroadcastMessage(message);

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
                        message = $"({DateTime.Now.ToShortTimeString()}) {Name}: {message}";
                        server.BroadcastMessage(message);
                    }
                    catch
                    {
                        message = Name + " покинул чат.";
                        server.BroadcastMessage(message);
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
                server.RemoveClient(this);
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
            var data = Encoding.Unicode.GetBytes(server.GetClients());
            Stream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            Stream?.Close();
            client?.Close();
        }
    }
}
