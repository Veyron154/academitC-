using System;
using System.Linq;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class CashMachineForm : Form
    {
        private readonly Model.CashMachine _cashMachine;

        public CashMachineForm()
        {
            InitializeComponent();

            _cashMachine = new Model.CashMachine();
            sumTextBox.Text = _cashMachine.TotalCountOfMoney.ToString();
        }

        private void putCashButton_Click(object sender, EventArgs e)
        {
            var putCashForm = new PutCashForm(_cashMachine);
            if (putCashForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            _cashMachine.CalculateMoney();
            sumTextBox.Text = _cashMachine.TotalCountOfMoney.ToString();
        }

        private void getCashButton_Click(object sender, EventArgs e)
        {
            var getCashForm = new GetCashForm(_cashMachine);
            if (getCashForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            _cashMachine.CalculateMoney();
            sumTextBox.Text = _cashMachine.TotalCountOfMoney.ToString();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            var message = "Сейчас в банкомате:\n";
            message += string.Join("\n", _cashMachine.ListOfBills.Select(b => $"{b.Name} - {b.Count} шт.").ToList());
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
