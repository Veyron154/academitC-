using System;
using System.Windows.Forms;

namespace ChatClient.View
{
    public partial class EnterForm : Form
    {
        public new string Name { get; private set; }

        public EnterForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                const string message = "Имя должно состоять минимум из одного символа";
                const string title = "Ошибка";
                MessageBox.Show(message, title, MessageBoxButtons.OK);
                return;
            }
            Name = textName.Text;
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
