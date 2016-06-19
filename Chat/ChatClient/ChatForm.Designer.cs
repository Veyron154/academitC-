namespace ChatClient
{
    partial class ChatForm
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
            this.textField = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.clientsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textField
            // 
            this.textField.Location = new System.Drawing.Point(12, 12);
            this.textField.Name = "textField";
            this.textField.ReadOnly = true;
            this.textField.Size = new System.Drawing.Size(360, 211);
            this.textField.TabIndex = 0;
            this.textField.Text = "";
            // 
            // textBox
            // 
            this.textBox.Enabled = false;
            this.textBox.Location = new System.Drawing.Point(12, 229);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(360, 20);
            this.textBox.TabIndex = 1;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(387, 12);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(85, 30);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "Вход";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(387, 219);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(85, 30);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Ввод";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Enabled = false;
            this.exitButton.Location = new System.Drawing.Point(387, 49);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(85, 30);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // clientsButton
            // 
            this.clientsButton.Enabled = false;
            this.clientsButton.Location = new System.Drawing.Point(387, 126);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Size = new System.Drawing.Size(85, 35);
            this.clientsButton.TabIndex = 5;
            this.clientsButton.Text = "Список участников";
            this.clientsButton.UseVisualStyleBackColor = true;
            this.clientsButton.Click += new System.EventHandler(this.clientsButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.clientsButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.textField);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textField;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button clientsButton;
    }
}

