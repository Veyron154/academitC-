using System;
using System.Windows.Forms;
using ChatClient.Model;

namespace ChatClient.View
{
    public partial class ChatForm : Form, IChatForm
    {
        private EnterForm _enterForm;
        private IClient _client;
        private int _port;

        private bool Connected { get; set; }

        public ChatForm(int port)
        {
            InitializeComponent();
            _port = port;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            _enterForm = new EnterForm();
            if (_enterForm.ShowDialog(this) != DialogResult.OK || Connected)
            {
                return;
            }
            _client = new Client(_enterForm.Name, this, _port);
            _client.Connect();
            Connected = true;
            sendButton.Enabled = true;
            textBox.Enabled = true;
            exitButton.Enabled = true;
            clientsButton.Enabled = true;
            enterButton.Enabled = false;
        }

        public void WriteMessage(string message)
        {
            Invoke(new Action(delegate
            {
                if (textField.Text != "")
                {
                    textField.Text += Environment.NewLine + message;
                    return;
                }
                textField.Text = message;
            }));
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _client.SendMessage(textBox.Text);
            Invoke(new Action(delegate
            {
                textBox.Text = "";
            }));
            enterButton.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                WriteMessage($"({DateTime.Now.ToShortTimeString()}) Вы покинули чат.");
            }
            _client.Disconnect();
            sendButton.Enabled = false;
            textBox.Enabled = false;
            exitButton.Enabled = false;
            clientsButton.Enabled = false;
            enterButton.Enabled = true;
            Connected = false;
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            _client.SendMessage("GET_CLIENTS");
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client?.Disconnect();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 10)
            {
                return;
            }
            sendButton_Click(sender, e);
            e.Handled = true;
        }
    }
}
