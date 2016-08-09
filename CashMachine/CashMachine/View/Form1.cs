using System;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class CashMachineForm : Form
    {
        private Model.CashMachine _cashMachine;

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
            MessageBox.Show($"Сейчас в банкомате:\n10 руб. - {_cashMachine.CountOfTenBills} шт.\n" + 
                $"50 руб. - {_cashMachine.CountOfFiftyBills} шт.\n100 руб. - {_cashMachine.CountOfHundredBills} шт.\n" + 
                $"500 руб. - {_cashMachine.CountOfFiveHundredBills} шт.\n1000 руб. - {_cashMachine.CountOfThousandBills} шт.\n" + 
                $"5000 руб. - {_cashMachine.CountOfFiveThousandBills} шт.", "Информация", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
