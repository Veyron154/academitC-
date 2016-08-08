using System;
using System.Windows.Forms;
using TextCutter.Model;

namespace TextCutter.View
{
    public partial class TextCutterForm : Form
    {
        public TextCutterForm()
        {
            InitializeComponent();
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void outputFileButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputFileTextBox.Text))
            {
                MessageBox.Show("Выберите входной файл", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(outputFileTextBox.Text))
            {
                MessageBox.Show("Выберите выходной файл", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int minWordSize;
            if (int.TryParse(wordSizeTextBox.Text, out minWordSize) && minWordSize <= 0)
            {
                MessageBox.Show("Укажите минимальную длину слов \n (положительное число)", "Ошибка заполнения", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var textCutter = new FileTextCutter(inputFileTextBox.Text, outputFileTextBox.Text, int.Parse(wordSizeTextBox.Text), 
                punctuationMarksCheckBox.Checked);
            var result = textCutter.Cut();

            if (result == TextCutterResult.Ok)
            {
                MessageBox.Show("Выполнено", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (result == TextCutterResult.Error)
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
