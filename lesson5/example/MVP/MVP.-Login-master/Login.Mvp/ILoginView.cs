using System;

namespace Login
{
    public interface ILoginView
    {
        string UserName { set; get; }
        string Password { set; get; }

        event EventHandler<EventArgs> Login;

        void LetUserLogin();
        void DontLetUserLogin();
    }
}
