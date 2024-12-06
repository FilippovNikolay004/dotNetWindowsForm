using System;
using System.Windows.Forms;

namespace Login
{
    // Представление отвечает только за взаимодействие с пользователем
    // Это соответствует принципу единственной обязанности
    public partial class LoginForm : Form, ILoginView
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region ILoginView Implementation

        public string UserName
        {
            set { textBoxUserName.Text = value; }
            get { return textBoxUserName.Text.Trim();  }
        }

        public string Password
        {
            set { textBoxPassword.Text = value; }
            get { return textBoxPassword.Text.Trim(); }
        }

        // Представление выставляет наружу подписку на происходящие в нем события
        public event EventHandler<EventArgs> Login;

        public void LetUserLogin()
        {
            DialogResult = DialogResult.OK;
        }

        public void DontLetUserLogin()
        {
            MessageBox.Show("Wrong user name or/and password.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion ILoginView Implementation

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = UserName.Length >= 3 && Password.Length >= 6;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Представление оповещает подписчиков (Презентер) о событии нажатия на кнопку
            Login?.Invoke(this, EventArgs.Empty);
        }
    }
}
