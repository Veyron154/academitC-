using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CashMachine.Model.Exceptions;

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

            Size = new Size(300, 130 + (25 * i));
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            var listOfTextBoxesValues = _listOfTextBoxes.Select(i => i.Text).ToList();
            try
            {
                var sum = _cashMachine.PutCash(listOfTextBoxesValues);
                MessageBox.Show($"Счёт пополнен на {sum} рублей", "Выполнено", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Hide();
            }
            catch (InvalidValueOfBillException ex)
            {
                MessageBox.Show($"Операция не выполнена\nВведите корректное количество {ex.BillName} купюр", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FullnessCashMachineException ex)
            {
                MessageBox.Show($"Операция не выполнена\nБанкомат не может принять такое количество {ex.BillName} купюр", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
