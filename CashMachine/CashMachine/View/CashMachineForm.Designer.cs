namespace CashMachine.View
{
    partial class CashMachineForm
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
            this.getCashLabel = new System.Windows.Forms.Label();
            this.getCashButton = new System.Windows.Forms.Button();
            this.putCashLabel = new System.Windows.Forms.Label();
            this.putCashButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.infoButton = new System.Windows.Forms.Button();
            this.rubLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sumLabel
            // 
            this.sumLabel.AutoSize = true;
            this.sumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumLabel.Location = new System.Drawing.Point(12, 12);
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Size = new System.Drawing.Size(214, 20);
            this.sumLabel.TabIndex = 0;
            this.sumLabel.Text = "Общая сумма в банкомате:";
            // 
            // sumTextBox
            // 
            this.sumTextBox.Enabled = false;
            this.sumTextBox.Location = new System.Drawing.Point(245, 12);
            this.sumTextBox.Name = "sumTextBox";
            this.sumTextBox.Size = new System.Drawing.Size(59, 20);
            this.sumTextBox.TabIndex = 1;
            // 
            // getCashLabel
            // 
            this.getCashLabel.AutoSize = true;
            this.getCashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getCashLabel.Location = new System.Drawing.Point(12, 51);
            this.getCashLabel.Name = "getCashLabel";
            this.getCashLabel.Size = new System.Drawing.Size(162, 20);
            this.getCashLabel.TabIndex = 2;
            this.getCashLabel.Text = "Получить наличные";
            // 
            // getCashButton
            // 
            this.getCashButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getCashButton.Location = new System.Drawing.Point(245, 48);
            this.getCashButton.Name = "getCashButton";
            this.getCashButton.Size = new System.Drawing.Size(100, 23);
            this.getCashButton.TabIndex = 3;
            this.getCashButton.Text = "Получить";
            this.getCashButton.UseVisualStyleBackColor = true;
            this.getCashButton.Click += new System.EventHandler(this.getCashButton_Click);
            // 
            // putCashLabel
            // 
            this.putCashLabel.AutoSize = true;
            this.putCashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.putCashLabel.Location = new System.Drawing.Point(12, 92);
            this.putCashLabel.Name = "putCashLabel";
            this.putCashLabel.Size = new System.Drawing.Size(143, 20);
            this.putCashLabel.TabIndex = 4;
            this.putCashLabel.Text = "Внести наличные";
            // 
            // putCashButton
            // 
            this.putCashButton.Location = new System.Drawing.Point(245, 89);
            this.putCashButton.Name = "putCashButton";
            this.putCashButton.Size = new System.Drawing.Size(100, 23);
            this.putCashButton.TabIndex = 5;
            this.putCashButton.Text = "Внести";
            this.putCashButton.UseVisualStyleBackColor = true;
            this.putCashButton.Click += new System.EventHandler(this.putCashButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.Location = new System.Drawing.Point(12, 132);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(200, 20);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Информация по купюрам";
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(245, 129);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(100, 23);
            this.infoButton.TabIndex = 7;
            this.infoButton.Text = "Информация";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // rubLabel
            // 
            this.rubLabel.AutoSize = true;
            this.rubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rubLabel.Location = new System.Drawing.Point(310, 16);
            this.rubLabel.Name = "rubLabel";
            this.rubLabel.Size = new System.Drawing.Size(35, 16);
            this.rubLabel.TabIndex = 8;
            this.rubLabel.Text = "руб.";
            // 
            // CashMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.Controls.Add(this.rubLabel);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.putCashButton);
            this.Controls.Add(this.putCashLabel);
            this.Controls.Add(this.getCashButton);
            this.Controls.Add(this.getCashLabel);
            this.Controls.Add(this.sumTextBox);
            this.Controls.Add(this.sumLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(380, 200);
            this.MinimumSize = new System.Drawing.Size(380, 200);
            this.Name = "CashMachineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банкомат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.TextBox sumTextBox;
        private System.Windows.Forms.Label getCashLabel;
        private System.Windows.Forms.Button getCashButton;
        private System.Windows.Forms.Label putCashLabel;
        private System.Windows.Forms.Button putCashButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Label rubLabel;
    }
}

