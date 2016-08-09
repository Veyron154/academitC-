using System;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class PutCashForm : Form
    {
        private Model.CashMachine _cashMachine;

        public PutCashForm(Model.CashMachine cashMachine)
        {
            InitializeComponent();
            _cashMachine = cashMachine;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var countOfTenBills = 0;
            var countOfFiftyBills = 0;
            var countOfHundredBills = 0;
            var countOfFiveHundredBills = 0;
            var countOfThousandBills = 0;
            var countOfFiveThousandBills = 0;

            if (!CheckToCorrectValue(tenBillsTextBox.Text, ref countOfTenBills, "10 руб.") || 
                !CheckToCorrectValue(fiftyBillsTextBox.Text, ref countOfFiftyBills, "50 руб.") || 
                !CheckToCorrectValue(hundredBillsTextBox.Text, ref countOfHundredBills, "100 руб.") ||
                !CheckToCorrectValue(fiveHundredBillsTextBox.Text, ref countOfFiveHundredBills, "500 руб.") ||
                !CheckToCorrectValue(thousandBillsTextBox.Text, ref countOfThousandBills, "1000 руб.") ||
                !CheckToCorrectValue(fiveThousandBillsTextBox.Text, ref countOfFiveThousandBills, "5000 руб."))
            {
                return;
            }

            if (!CheckToFullness(countOfTenBills, _cashMachine.CountOfTenBills, "10 руб.") ||
                !CheckToFullness(countOfFiftyBills, _cashMachine.CountOfFiftyBills, "50 руб.") ||
                !CheckToFullness(countOfHundredBills, _cashMachine.CountOfHundredBills, "100 руб.") ||
                !CheckToFullness(countOfFiveHundredBills, _cashMachine.CountOfFiveHundredBills, "500 рус.") ||
                !CheckToFullness(countOfThousandBills, _cashMachine.CountOfThousandBills, "1000 руб.") ||
                !CheckToFullness(countOfFiveThousandBills, _cashMachine.CountOfFiveThousandBills, "5000 руб."))
            {
                return;
            }

            var sum = 0;
            _cashMachine.CountOfTenBills += countOfTenBills;
            sum += countOfTenBills * 10;
            _cashMachine.CountOfFiftyBills += countOfFiftyBills;
            sum += countOfFiftyBills * 50;
            _cashMachine.CountOfHundredBills += countOfHundredBills;
            sum += countOfHundredBills * 100;
            _cashMachine.CountOfFiveHundredBills += countOfFiveHundredBills;
            sum += countOfFiveHundredBills * 500;
            _cashMachine.CountOfThousandBills += countOfThousandBills;
            sum += countOfThousandBills * 1000;
            _cashMachine.CountOfFiveThousandBills += countOfFiveThousandBills;
            sum += countOfFiveThousandBills * 5000;

            MessageBox.Show($"Счёт пополнен на {sum} рублей", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private bool CheckToCorrectValue(string textBoxText, ref int countOfBills, string cashValue)
        {
            if (!int.TryParse(textBoxText, out countOfBills) || countOfBills < 0)
            {
                MessageBox.Show($"Операция не выполнена \n Введите корректное количество {cashValue} купюр", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool CheckToFullness(int countOfBills, int curentCountOfBills, string cash)
        {
            if (countOfBills + curentCountOfBills > _cashMachine.MaxCountOfBills)
            {
                MessageBox.Show($"Операция не выполнена \n Банкомат не может принять такое количество {cash} купюр", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
