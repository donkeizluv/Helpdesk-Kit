using System;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public struct AccountCredentials
    {
        public string Username;
        public string Pwd;
    }

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            button1_Click(null, EventArgs.Empty);
        }

        public AccountCredentials GetCredentials()
        {
            return new AccountCredentials
            {
                Username = textBoxUsername.Text,
                Pwd = textBoxPwd.Text
            };
        }
    }
}