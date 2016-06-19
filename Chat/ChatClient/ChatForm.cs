
using System;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ChatForm : Form, IChatForm
    {
        private EnterForm enterForm;
        private IClient client;
        private bool Connected { get; set; }

        public ChatForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            enterForm = new EnterForm();
            if (enterForm.ShowDialog(this) != DialogResult.OK || Connected || enterForm.Name == "")
            {
                return;
            }
            client = new Client(enterForm.Name, this);
            client.Connect();
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
                    textField.Text += "\n" + message;
                    return;
                }
                textField.Text = message;
            }));
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            client.SendMessage(textBox.Text);
            Invoke(new Action(delegate
            {
                textBox.Text = "";
            }));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            sendButton.Enabled = false;
            textBox.Enabled = false;
            exitButton.Enabled = false;
            clientsButton.Enabled = false;
            enterButton.Enabled = true;
            Connected = false;
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            client.SendMessage("GET_CLIENTS");
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client?.Disconnect();
        }
    }
}
