using System;
using System.Windows.Forms;
using TextCutter.Model;

namespace TextCutter.Viev
{
    public partial class TextCutterForm : Form
    {
        public TextCutterForm()
        {
            InitializeComponent();
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void outputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if(inputFileTextBox.Text == "")
            {
                MessageBox.Show("Выберите входной файл", "Ошибка заполнения", MessageBoxButtons.OK);
                return;
            }
            if (outputFileTextBox.Text == "")
            {
                MessageBox.Show("Выберите выходной файл", "Ошибка заполнения", MessageBoxButtons.OK);
                return;
            }
            if(wordSizeTextBox.Text == "0")
            {
                MessageBox.Show("Укажите минимальную длину слов", "Ошибка заполнения", MessageBoxButtons.OK);
                return;
            }

            ITextCutter textCutter = new FileTextCutter(inputFileTextBox.Text, outputFileTextBox.Text, int.Parse(wordSizeTextBox.Text), 
                punctuationMarksCheckBox.Checked);
            TextCutterResult result = textCutter.Cut();

            if(result == TextCutterResult.Ok)
            {
                MessageBox.Show("Выполнено", "Выполнено", MessageBoxButtons.OK);
            }
            if (result == TextCutterResult.Error)
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
