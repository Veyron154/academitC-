using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    internal class Server
    {
        private TcpListener listener;
        private readonly List<ClientInstance> clients;
        private readonly int port;

        public Server()
        {
            this.port = int.Parse(ConfigurationManager.AppSettings["port"]);
            clients = new List<ClientInstance>();
        }

        public void Start()
        {
            var thread = new Thread(Listen);
            thread.Start();
        }

        public void RemoveClient(ClientInstance client)
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
                    var clientInstance = new ClientInstance(tcpClient, this);
                    clients.Add(clientInstance);
                    clientInstance.Start();
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
            return "Список участников:" + Environment.NewLine + string.Join(Environment.NewLine, 
                clients.Select(c => c.Name));
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
