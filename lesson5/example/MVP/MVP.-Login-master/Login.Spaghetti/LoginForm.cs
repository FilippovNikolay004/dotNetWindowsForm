using System;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginForm : Form
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private bool IsLoginCorrect()
        {
            // Потенциально в коде метода происходит обращение
            // к базе данных и поиск совпадения логина/пароля
            return UserName == "MVP" && Password == "qwerty";
        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            UserName = textBoxUserName.Text.Trim();
            Password = textBoxPassword.Text.Trim();
            buttonOk.Enabled = UserName.Length >= 3 && Password.Length >= 6;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IsLoginCorrect())
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Wrong user name or/and password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
