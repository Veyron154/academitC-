using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    internal class Server
    {
        private TcpListener listener;
        private readonly List<ClientObject> clients;
        private readonly int port;

        public Server(int port)
        {
            this.port = port;
            clients = new List<ClientObject>();
        }

        public void AddClient(ClientObject client)
        {
            clients.Add(client);
        }

        public void RemoveClient(ClientObject client)
        {
            clients.Remove(client);
        }

        public void Listen()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Сервер запущен");

                while (true)
                {
                    var tcpClient = listener.AcceptTcpClient();
                    var clientObject = new ClientObject(tcpClient, this);
                    var clientThread = new Thread(clientObject.Process);
                    clientThread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        public void BroadcastMessage(string message)
        {
            var data = Encoding.Unicode.GetBytes(message);

            foreach (var client in clients)
            {
                client.Stream.Write(data, 0, data.Length);
            }
        }

        public string GetClients()
        {
            var builder = new StringBuilder();
            builder.Append("Список участников:\n");
            foreach (var client in clients)
            {
                builder.Append(client.Name + "\n");
            }
            return builder.ToString();
        }

        public void Disconnect()
        {
            listener.Stop();
            foreach (var client in clients)
            {
                client.Disconnect();
            }
            Environment.Exit(0);
        }
    }
}
