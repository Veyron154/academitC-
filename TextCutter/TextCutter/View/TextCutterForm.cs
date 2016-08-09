using System;
using System.Windows.Forms;
using System.IO;
using TextCutter.Model;

namespace TextCutter.View
{
    public partial class TextCutterForm : Form
    {
        private const string fileFilter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        public TextCutterForm()
        {
            InitializeComponent();
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = fileFilter
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void outputFileButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = fileFilter
            };

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
            if (!int.TryParse(wordSizeTextBox.Text, out minWordSize) || minWordSize <= 0)
            {
                MessageBox.Show("Укажите минимальную длину слов \n (положительное число)", "Ошибка заполнения", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var textCutter = new FileTextCutter(inputFileTextBox.Text, outputFileTextBox.Text, minWordSize,
                    punctuationMarksCheckBox.Checked);
                textCutter.Cut();

                MessageBox.Show("Выполнено", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Произошла ошибка \n Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка \n Детали ошибки:" + Environment.NewLine + ex.ToString(), "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
