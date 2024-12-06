using System;
using System.Windows.Forms;

namespace Login
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Ok, got you.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
