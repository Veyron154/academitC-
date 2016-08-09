using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class GetCashForm : Form
    {
        private readonly Model.CashMachine _cashMachine;
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

            List<int> listOfCountsOfBills = new List<int>();
            foreach (var rating in _cashMachine.ListOfRatings)
            {
                listOfCountsOfBills.Add(new int());
            }

            var tmpSum = _sum;

            var index = cashComboBox.SelectedIndex;
            listOfCountsOfBills[index] = CalculateBills(listOfCountsOfBills[index], _cashMachine.ListOfRatings[index].Value, 
                _cashMachine.ListOfRatings[index].Count);

            for (var i = listOfCountsOfBills.Count -1; i >= 0; --i)
            {
                if (i == index)
                {
                    continue;
                }
                var rating = _cashMachine.ListOfRatings[i];
                listOfCountsOfBills[i] = CalculateBills(listOfCountsOfBills[i], rating.Value, rating.Count);
            }
            
            if (_sum != 0)
            {
                MessageBox.Show("Невозможно подобрать необходимую сумму, пожалуйста введите другую сумму", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                _cashMachine.ListOfRatings[i].Count -= listOfCountsOfBills[i];
            }

            var stringBuilder = new StringBuilder("Выдано:");
            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                if(listOfCountsOfBills[i] != 0)
                {
                    stringBuilder.Append($"\n{_cashMachine.ListOfRatings[i].Name} - {listOfCountsOfBills[i]} шт.");
                }
            }
            stringBuilder.Append($"\nОбщая сумма - {tmpSum} руб.");
            MessageBox.Show(stringBuilder.ToString(), "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private int CalculateBills(int requestedCountOfBills, int cash, int countOfBills)
        {
            requestedCountOfBills = _sum / cash;
            if (requestedCountOfBills > countOfBills)
            {
                requestedCountOfBills = countOfBills;
            }
            _sum -= requestedCountOfBills * cash;
            return requestedCountOfBills;
        }
    }
}
