using System;
using System.Text;
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
            var stringBuilder = new StringBuilder("Сейчас в банкомате:");
            foreach (var rating in _cashMachine.ListOfRatings)
            {
                stringBuilder.Append($"\n{rating.Name} - {rating.Count} шт.");
            }
            MessageBox.Show(stringBuilder.ToString(), "Информация", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
