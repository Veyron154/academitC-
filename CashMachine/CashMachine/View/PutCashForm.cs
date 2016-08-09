using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class PutCashForm : Form
    {
        private readonly Model.CashMachine _cashMachine;

        public PutCashForm(Model.CashMachine cashMachine)
        {
            InitializeComponent();
            _cashMachine = cashMachine;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            List<int> listOfCountsOfBills = new List<int>();
            foreach (var rating in _cashMachine.ListOfRatings)
            {
                listOfCountsOfBills.Add(new int());
            }

            List<string> listOfTextBoxesText = new List<string>();
            listOfTextBoxesText.Add(tenBillsTextBox.Text);
            listOfTextBoxesText.Add(fiftyBillsTextBox.Text);
            listOfTextBoxesText.Add(hundredBillsTextBox.Text);
            listOfTextBoxesText.Add(fiveHundredBillsTextBox.Text);
            listOfTextBoxesText.Add(thousandBillsTextBox.Text);
            listOfTextBoxesText.Add(fiveThousandBillsTextBox.Text);

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                listOfCountsOfBills[i] = CheckToCorrectValue(listOfTextBoxesText[i], listOfCountsOfBills[i], 
                    _cashMachine.ListOfRatings[i].Name);
                if (listOfCountsOfBills[i] == -1)
                {
                    return;
                }
            }

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                var rating = _cashMachine.ListOfRatings[i];
                if (!CheckToFullness(listOfCountsOfBills[i], rating.Count, rating.Name))
                {
                    return;
                }
            }

            var sum = 0;
            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                var rating = _cashMachine.ListOfRatings[i];
                rating.Count += listOfCountsOfBills[i];
                sum += listOfCountsOfBills[i] * rating.Value;
            }

            MessageBox.Show($"Счёт пополнен на {sum} рублей", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private int CheckToCorrectValue(string textBoxText, int countOfBills, string cashValue)
        {
            if (!int.TryParse(textBoxText, out countOfBills) || countOfBills < 0)
            {
                MessageBox.Show($"Операция не выполнена \n Введите корректное количество {cashValue} купюр", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return countOfBills;
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
