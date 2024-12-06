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
            IModel model = new Model();
            LoginPresenter loginPresenter = new LoginPresenter(model, loginForm);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Ok, got you.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
