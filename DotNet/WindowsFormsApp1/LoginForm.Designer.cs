namespace WindowsFormsApp1
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._loginButton = new System.Windows.Forms.Button();
            this._emailAddressTextBox = new System.Windows.Forms.TextBox();
            this._demoPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(261, 110);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(117, 44);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _loginButton
            // 
            this._loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._loginButton.Location = new System.Drawing.Point(387, 110);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(117, 44);
            this._loginButton.TabIndex = 4;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this._loginButton_Click);
            // 
            // _emailAddressTextBox
            // 
            this._emailAddressTextBox.Location = new System.Drawing.Point(137, 26);
            this._emailAddressTextBox.Name = "_emailAddressTextBox";
            this._emailAddressTextBox.Size = new System.Drawing.Size(367, 22);
            this._emailAddressTextBox.TabIndex = 1;
            this._emailAddressTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // _demoPasswordTextBox
            // 
            this._demoPasswordTextBox.Location = new System.Drawing.Point(137, 68);
            this._demoPasswordTextBox.Name = "_demoPasswordTextBox";
            this._demoPasswordTextBox.PasswordChar = '*';
            this._demoPasswordTextBox.Size = new System.Drawing.Size(367, 22);
            this._demoPasswordTextBox.TabIndex = 3;
            this._demoPasswordTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // LoginForm
            // 
            this.AcceptButton = this._loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(537, 186);
            this.Controls.Add(this._demoPasswordTextBox);
            this.Controls.Add(this._emailAddressTextBox);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Effortless Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.TextBox _emailAddressTextBox;
        private System.Windows.Forms.TextBox _demoPasswordTextBox;
    }
}