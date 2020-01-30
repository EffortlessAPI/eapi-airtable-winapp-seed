using EffortlessApi.SassyMQ.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string AMQPSConnectionString { get; set; }
        private SMQUser User { get; set; }
        public SMQAdmin Admin { get; }
        protected SMQGuest Guest { get; set; }
        public string AccessToken { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.CheckUsersCredentials();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.AccessToken)) this.Close();
            else
            {
                var payload = Admin.CreatePayload();
                Admin.GetMediaItems(payload, (nsReply, nsBdea) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.dataGridView1.DataSource = nsReply.MediaItems;
                    }));
                }, (error, ebdea) =>
                {
                    this.ShowError("ERROR: {0}", error.ErrorMessage);
                });
            }
        }

        private void CheckUsersCredentials()
        {
            this.AMQPSConnectionString = ConfigurationManager.AppSettings["amqpsConnectionString"];
            this.Guest = new SMQGuest(AMQPSConnectionString);
            this.User = new SMQUser(this.AMQPSConnectionString);
            this.Admin = new SMQAdmin(this.AMQPSConnectionString);

            var loginForm = new LoginForm();

            if (loginForm.AuthenticateUser(this.Guest, this.ShowError))
            {
                this.AccessToken = loginForm.AccessToken;
                this.Admin.AccessToken = this.Guest.AccessToken = this.User.AccessToken = this.AccessToken;
            }
        }

        private void ShowError(string formatString, params object[] args)
        {
            if (args == null) args = new object[] { };
            var msg = String.Format(formatString, args);
            MessageBox.Show(msg);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Guest.Disconnect();
            if (this.User != null) this.User.Disconnect();
            base.OnClosing(e);
        }
    }
}
