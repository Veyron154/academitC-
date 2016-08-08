namespace TextCutter.Viev
{
    partial class TextCutterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputFileLable = new System.Windows.Forms.Label();
            this.inputFileButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.outputFileLable = new System.Windows.Forms.Label();
            this.outputFileButton = new System.Windows.Forms.Button();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.wordSizeLable = new System.Windows.Forms.Label();
            this.wordSizeTextBox = new System.Windows.Forms.TextBox();
            this.punctuationMarksCheckBox = new System.Windows.Forms.CheckBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileLable
            // 
            this.inputFileLable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inputFileLable.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.inputFileLable, 2);
            this.inputFileLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputFileLable.Location = new System.Drawing.Point(3, 6);
            this.inputFileLable.Name = "inputFileLable";
            this.inputFileLable.Size = new System.Drawing.Size(138, 24);
            this.inputFileLable.TabIndex = 0;
            this.inputFileLable.Text = "Входной файл";
            // 
            // inputFileButton
            // 
            this.inputFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inputFileButton.Location = new System.Drawing.Point(3, 42);
            this.inputFileButton.Name = "inputFileButton";
            this.inputFileButton.Size = new System.Drawing.Size(97, 24);
            this.inputFileButton.TabIndex = 1;
            this.inputFileButton.Text = "Выбрать";
            this.inputFileButton.UseVisualStyleBackColor = true;
            this.inputFileButton.Click += new System.EventHandler(this.inputFileButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.inputFileTextBox, 2);
            this.inputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputFileTextBox.Location = new System.Drawing.Point(113, 43);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(568, 22);
            this.inputFileTextBox.TabIndex = 2;
            // 
            // outputFileLable
            // 
            this.outputFileLable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.outputFileLable.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.outputFileLable, 2);
            this.outputFileLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputFileLable.Location = new System.Drawing.Point(3, 78);
            this.outputFileLable.Name = "outputFileLable";
            this.outputFileLable.Size = new System.Drawing.Size(151, 24);
            this.outputFileLable.TabIndex = 3;
            this.outputFileLable.Text = "Выходной файл";
            // 
            // outputFileButton
            // 
            this.outputFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.outputFileButton.Location = new System.Drawing.Point(3, 114);
            this.outputFileButton.Name = "outputFileButton";
            this.outputFileButton.Size = new System.Drawing.Size(97, 24);
            this.outputFileButton.TabIndex = 4;
            this.outputFileButton.Text = "Выбрать";
            this.outputFileButton.UseVisualStyleBackColor = true;
            this.outputFileButton.Click += new System.EventHandler(this.outputFileButton_Click);
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.outputFileTextBox, 2);
            this.outputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputFileTextBox.Location = new System.Drawing.Point(113, 115);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(568, 22);
            this.outputFileTextBox.TabIndex = 5;
            // 
            // wordSizeLable
            // 
            this.wordSizeLable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.wordSizeLable.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.wordSizeLable, 2);
            this.wordSizeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordSizeLable.Location = new System.Drawing.Point(3, 150);
            this.wordSizeLable.Name = "wordSizeLable";
            this.wordSizeLable.Size = new System.Drawing.Size(245, 24);
            this.wordSizeLable.TabIndex = 6;
            this.wordSizeLable.Text = "Минимальная длина слов:";
            // 
            // wordSizeTextBox
            // 
            this.wordSizeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.wordSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordSizeTextBox.Location = new System.Drawing.Point(263, 151);
            this.wordSizeTextBox.Name = "wordSizeTextBox";
            this.wordSizeTextBox.Size = new System.Drawing.Size(100, 22);
            this.wordSizeTextBox.TabIndex = 7;
            this.wordSizeTextBox.Text = "0";
            // 
            // punctuationMarksCheckBox
            // 
            this.punctuationMarksCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.punctuationMarksCheckBox.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.punctuationMarksCheckBox, 3);
            this.punctuationMarksCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.punctuationMarksCheckBox.Location = new System.Drawing.Point(3, 184);
            this.punctuationMarksCheckBox.Name = "punctuationMarksCheckBox";
            this.punctuationMarksCheckBox.Size = new System.Drawing.Size(274, 28);
            this.punctuationMarksCheckBox.TabIndex = 8;
            this.punctuationMarksCheckBox.Text = "Удалить знаки препинания";
            this.punctuationMarksCheckBox.UseVisualStyleBackColor = true;
            // 
            // executeButton
            // 
            this.executeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel.SetColumnSpan(this.executeButton, 3);
            this.executeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeButton.Location = new System.Drawing.Point(297, 223);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(90, 30);
            this.executeButton.TabIndex = 9;
            this.executeButton.Text = "Выполнить";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.inputFileLable, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.executeButton, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.inputFileButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.punctuationMarksCheckBox, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.inputFileTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.outputFileLable, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.outputFileButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.outputFileTextBox, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.wordSizeLable, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.wordSizeTextBox, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(684, 261);
            this.tableLayoutPanel.TabIndex = 10;
            // 
            // TextCutterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "TextCutterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработчик текста";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputFileLable;
        private System.Windows.Forms.Button inputFileButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.Label outputFileLable;
        private System.Windows.Forms.Button outputFileButton;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Label wordSizeLable;
        private System.Windows.Forms.TextBox wordSizeTextBox;
        private System.Windows.Forms.CheckBox punctuationMarksCheckBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}

