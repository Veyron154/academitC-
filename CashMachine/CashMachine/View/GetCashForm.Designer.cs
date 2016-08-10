namespace CashMachine.View
{
    partial class GetCashForm
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
            this.sumLabel = new System.Windows.Forms.Label();
            this.sumTextBox = new System.Windows.Forms.TextBox();
            this.cashLabel = new System.Windows.Forms.Label();
            this.cashComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sumLabel
            // 
            this.sumLabel.AutoSize = true;
            this.sumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumLabel.Location = new System.Drawing.Point(13, 13);
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Size = new System.Drawing.Size(128, 20);
            this.sumLabel.TabIndex = 0;
            this.sumLabel.Text = "Введите сумму:";
            // 
            // sumTextBox
            // 
            this.sumTextBox.Location = new System.Drawing.Point(173, 12);
            this.sumTextBox.Name = "sumTextBox";
            this.sumTextBox.Size = new System.Drawing.Size(100, 20);
            this.sumTextBox.TabIndex = 1;
            this.sumTextBox.Text = "0";
            // 
            // cashLabel
            // 
            this.cashLabel.AutoSize = true;
            this.cashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashLabel.Location = new System.Drawing.Point(13, 46);
            this.cashLabel.Name = "cashLabel";
            this.cashLabel.Size = new System.Drawing.Size(283, 20);
            this.cashLabel.TabIndex = 2;
            this.cashLabel.Text = "Какими купюрами хотите получить?";
            // 
            // cashComboBox
            // 
            this.cashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cashComboBox.FormattingEnabled = true;
            this.cashComboBox.IntegralHeight = false;
            this.cashComboBox.Location = new System.Drawing.Point(312, 44);
            this.cashComboBox.Name = "cashComboBox";
            this.cashComboBox.Size = new System.Drawing.Size(80, 21);
            this.cashComboBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(173, 76);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // GetCashForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 111);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cashComboBox);
            this.Controls.Add(this.cashLabel);
            this.Controls.Add(this.sumTextBox);
            this.Controls.Add(this.sumLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(425, 150);
            this.MinimumSize = new System.Drawing.Size(425, 150);
            this.Name = "GetCashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Получение наличных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.TextBox sumTextBox;
        private System.Windows.Forms.Label cashLabel;
        private System.Windows.Forms.ComboBox cashComboBox;
        private System.Windows.Forms.Button okButton;
    }
}