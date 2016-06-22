
using System;

namespace Message
{
    [Serializable]
    public class ChatMessage
    {
        public string Data { get; private set; }

        public ChatMessage(string data)
        {
            Data = data;
        }
    }
}
