using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EffortlessApi.SassyMQ.Lib;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public SMQGuest Guest { get; internal set; }
        public string AccessToken { get; private set; }
        public Action<string, object[]> ShowError { get; internal set; }

        internal bool AuthenticateUser(SMQGuest guest, Action<string, object[]> showError)
        {
            this.Guest = guest;
            this.ShowError = showError;
            return (this.ShowDialog() == DialogResult.OK);
        }

        private bool CheckValidation()
        {
            bool success = false;
            var waiting = true;
            var started = DateTime.Now;

            var payload = Guest.CreatePayload();
            payload.EmailAddress = _emailAddressTextBox.Text;
            payload.DemoPassword = _demoPasswordTextBox.Text;
            Guest.ValidateTemporaryAccessToken(payload, (reply, bdea) =>
            {
                this.AccessToken = reply.AccessToken;
                success = !String.IsNullOrEmpty(this.AccessToken);
                waiting = false;
            }, (error, ebdea) =>
            {
                this.ShowError(error.ErrorMessage, null);
                waiting = false;
            });

            Task.Factory.StartNew(() =>
            {
                while (waiting && (started.AddSeconds(30) > DateTime.Now))
                {
                    Thread.Sleep(10);
                }
                if (waiting) this.ShowError("Timed out waiting for response", null);
            }).Wait();
            return success;
        }

        private void _loginButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckValidation())
            {
                this.DialogResult = DialogResult.None;
                this.ShowError("Invalid login.  Please try again.", null);
                _demoPasswordTextBox.Text = String.Empty;
                _demoPasswordTextBox.Focus();
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
