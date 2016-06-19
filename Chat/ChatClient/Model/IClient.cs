
namespace ChatClient.Model
{
    internal interface IClient
    {
        void Connect();
        void Disconnect();
        void SendMessage(string message);
    }
}
