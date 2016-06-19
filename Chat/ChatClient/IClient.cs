
namespace ChatClient
{
    internal interface IClient
    {
        void Connect();
        void SendMessage(string message);
        void Disconnect();
    }
}
