using System;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class GetCashForm : Form
    {
        private Model.CashMachine _cashMachine;
        private int _sum;

        public GetCashForm(Model.CashMachine cashMachine)
        {
            InitializeComponent();
            _cashMachine = cashMachine;
            _sum = 0;
            cashComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sumTextBox.Text, out _sum) || _sum <= 0 || _sum % 10 != 0)
            {
                MessageBox.Show("Введите корректную сумму \nСумма должна быть положительна и кратна 10 руб.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_sum > _cashMachine.TotalCountOfMoney)
            {
                MessageBox.Show("В банкомате отсутствует такая сумма денег", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var countOfTenBills = 0;
            var countOfFiftyBills = 0;
            var countOfHundredBills = 0;
            var countOfFiveHundredBills = 0;
            var countOfThousandBills = 0;
            var countOfFiveThousandBills = 0;

            var tmpSum = _sum;

            switch (cashComboBox.SelectedIndex)
            {
                case 0:
                    CalculateBills(ref countOfTenBills, 10, _cashMachine.CountOfTenBills);
                    break;
                case 1:
                    CalculateBills(ref countOfFiftyBills, 50, _cashMachine.CountOfFiftyBills);
                    break;
                case 2:
                    CalculateBills(ref countOfHundredBills, 100, _cashMachine.CountOfHundredBills);
                    break;
                case 3:
                    CalculateBills(ref countOfFiveHundredBills, 500, _cashMachine.CountOfFiveHundredBills);
                    break;
                case 4:
                    CalculateBills(ref countOfThousandBills, 1000, _cashMachine.CountOfThousandBills);
                    break;
                case 5:
                    CalculateBills(ref countOfFiveThousandBills, 5000, _cashMachine.CountOfFiveThousandBills);
                    break;
            }

            if (countOfFiveThousandBills == 0)
            {
                CalculateBills(ref countOfFiveThousandBills, 5000, _cashMachine.CountOfFiveThousandBills);
            }
            if (countOfThousandBills == 0)
            {
                CalculateBills(ref countOfThousandBills, 1000, _cashMachine.CountOfThousandBills);
            }
            if (countOfFiveHundredBills == 0)
            {
                CalculateBills(ref countOfFiveHundredBills, 500, _cashMachine.CountOfFiveHundredBills);
            }
            if (countOfHundredBills == 0)
            {
                CalculateBills(ref countOfHundredBills, 100, _cashMachine.CountOfHundredBills);
            }
            if (countOfFiftyBills == 0)
            {
                CalculateBills(ref countOfFiftyBills, 50, _cashMachine.CountOfFiftyBills);
            }
            if (countOfTenBills == 0)
            {
                CalculateBills(ref countOfTenBills, 10, _cashMachine.CountOfTenBills);
            }

            if (_sum != 0)
            {
                MessageBox.Show("Невозможно подобрать необходимую сумму, пожалуйста введите другую сумму", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cashMachine.CountOfTenBills -= countOfTenBills;
            _cashMachine.CountOfFiftyBills -= countOfFiftyBills;
            _cashMachine.CountOfHundredBills -= countOfHundredBills;
            _cashMachine.CountOfFiveHundredBills -= countOfFiveHundredBills;
            _cashMachine.CountOfThousandBills -= countOfThousandBills;
            _cashMachine.CountOfFiveThousandBills -= countOfFiveThousandBills;

            MessageBox.Show($"Выдано:\n10 руб - {countOfTenBills} шт.\n50 руб - {countOfFiftyBills} шт.\n" + 
                $"100 руб. - {countOfHundredBills} шт.\n500 руб. - {countOfFiveHundredBills} шт.\n" + 
                $"1000 руб. - {countOfThousandBills} шт.\n5000 руб. - {countOfFiveThousandBills} шт.\nОбщая сумма - {tmpSum} руб.", 
                "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void CalculateBills(ref int requestedCountOfBills, int cash, int countOfBills)
        {
            requestedCountOfBills = _sum / cash;
            if (requestedCountOfBills > countOfBills)
            {
                requestedCountOfBills = countOfBills;
            }
            _sum -= requestedCountOfBills * cash;
        }
    }
}
