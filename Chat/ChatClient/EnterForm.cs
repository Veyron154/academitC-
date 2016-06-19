using System;
using System.Windows.Forms;

namespace ChatClient
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
            Name = textName.Text;
            if (Name != null)
            {
                DialogResult = DialogResult.OK;
            }
            Hide();
        }
    }
}
