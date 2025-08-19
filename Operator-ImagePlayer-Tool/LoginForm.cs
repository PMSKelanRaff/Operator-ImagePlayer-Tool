using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operator_ImagePlayer_Tool
{
    public partial class LoginForm : Form
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
