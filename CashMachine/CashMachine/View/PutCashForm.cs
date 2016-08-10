using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CashMachine.View
{
    public partial class PutCashForm : Form
    {
        private readonly Model.CashMachine _cashMachine;
        private readonly List<TextBox> _listOfTextBoxes;

        public PutCashForm(Model.CashMachine cashMachine)
        {
            InitializeComponent();
            _cashMachine = cashMachine;
            _listOfTextBoxes = new List<TextBox>();

            var i = 0;
            while(i < _cashMachine.ListOfBills.Count)
            {
                var textPoint = new Point(160, 50 + (25 * i));
                var textBox = new TextBox
                {
                    Text = "0",
                    Location = textPoint
                };

                var labelPoint = new Point(15, 50 + (25 * i));
                var label = new Label
                {
                    Text = _cashMachine.ListOfBills[i].Name,
                    Location = labelPoint
                };

                _listOfTextBoxes.Add(textBox);

                Controls.Add(label);
                Controls.Add(textBox);

                ++i;
            }

            MaximumSize = new Size(300, 130 + (25 * i));
            MinimumSize = new Size(300, 130 + (25 * i));
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            var listOfCountsOfBills = _cashMachine.ListOfBills.Select(rating => new int()).ToList();

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                listOfCountsOfBills[i] = CheckToCorrectValue(_listOfTextBoxes[i].Text, _cashMachine.ListOfBills[i].Name);
                if (listOfCountsOfBills[i] == -1)
                {
                    return;
                }
            }

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                var rating = _cashMachine.ListOfBills[i];
                if (!CheckToFullness(listOfCountsOfBills[i], rating.Count, rating.Name))
                {
                    return;
                }
            }

            var sum = 0;
            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                var rating = _cashMachine.ListOfBills[i];
                rating.Count += listOfCountsOfBills[i];
                sum += listOfCountsOfBills[i] * rating.Value;
            }

            MessageBox.Show($"Счёт пополнен на {sum} рублей", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private static int CheckToCorrectValue(string textBoxText, string cashValue)
        {
            int countOfBills;
            if (int.TryParse(textBoxText, out countOfBills) && countOfBills >= 0) return countOfBills;
            MessageBox.Show($"Операция не выполнена \n Введите корректное количество {cashValue} купюр", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }

        private bool CheckToFullness(int countOfBills, int curentCountOfBills, string cash)
        {
            if (countOfBills + curentCountOfBills <= _cashMachine.MaxCountOfBills) return true;
            MessageBox.Show($"Операция не выполнена \n Банкомат не может принять такое количество {cash} купюр", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
