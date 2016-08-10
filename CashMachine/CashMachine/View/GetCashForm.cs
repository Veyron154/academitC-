using System;
using System.Text;
using System.Windows.Forms;
using CashMachine.Model.Exceptions;

namespace CashMachine.View
{
    public partial class GetCashForm : Form
    {
        private readonly Model.CashMachine _cashMachine;

        public GetCashForm(Model.CashMachine cashMachine)
        {
            InitializeComponent();
            _cashMachine = cashMachine;

            foreach (var bill in _cashMachine.ListOfBills)
            {
                cashComboBox.Items.Add(bill.Name);
            }
            cashComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sumTextBox.Text))
            {
                MessageBox.Show("Введите сумму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var listOfCountsOfBills = _cashMachine.GetCash(sumTextBox.Text, cashComboBox.SelectedIndex);

                var stringBuilder = new StringBuilder("Выдано:");
                for (var i = 0; i < listOfCountsOfBills.Count; ++i)
                {
                    if (listOfCountsOfBills[i] != 0)
                    {
                        stringBuilder.Append($"\n{_cashMachine.ListOfBills[i].Name} - {listOfCountsOfBills[i]} шт.");
                    }
                }
                stringBuilder.Append($"\nОбщая сумма - {sumTextBox.Text} руб.");
                MessageBox.Show(stringBuilder.ToString(), "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Hide();
            }
            catch (InvalidValueOfSumException)
            {
                MessageBox.Show("Введите корректную сумму \nСумма должна быть положительна и кратна 10 руб.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceedingSumException)
            {
                MessageBox.Show("В банкомате отсутствует такая сумма денег", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (ImpossibleCashCombinationException)
            {
                MessageBox.Show("Невозможно подобрать необходимую сумму, пожалуйста введите другую сумму", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
