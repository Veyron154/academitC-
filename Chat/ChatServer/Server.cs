using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        private readonly bool logged;

        public Server()
        {
            port = int.Parse(ConfigurationManager.AppSettings["port"]);
            clients = new List<ClientInstance>();
            logged = bool.Parse(ConfigurationManager.AppSettings["logged"]);
        }

        public void Start()
        {
            var thread = new Thread(Listen);
            thread.Start();
        }

        public void RemoveClient(ClientInstance client)
        {
            WriteInLog($"({DateTime.Now}) {client.Name} покинул чат.");
            clients.Remove(client);
        }

        public void Listen()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Сервер запущен");
                WriteInLog($"({DateTime.Now}) Сервер запущен.");

                while (true)
                {
                    var tcpClient = listener.AcceptTcpClient();
                    var clientInstance = new ClientInstance(tcpClient, this);
                    clients.Add(clientInstance);
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

        public void WriteInLog(string message)
        {
            if (!logged)
            {
                return;
            }
            var sw = new StreamWriter("Log.txt", true);
            sw.WriteLine(message);
            sw.Close();
        }
    }
}
