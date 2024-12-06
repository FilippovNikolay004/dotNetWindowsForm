using System;

namespace Login
{
    public class LoginPresenter
    {
        private readonly IModel _model;
        private readonly ILoginView _view;

        // Принцип инверсии зависимостей
        public LoginPresenter(IModel model, ILoginView view)
        {
            _model = model;
            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.Login += new EventHandler<EventArgs>(OnLogin);
            UpdateView();
        }

        private void OnLogin(object sender, EventArgs e)
        {
            // В ответ на изменения в Представлении необходимо изменить Модель
            _model.UserName = _view.UserName;
            _model.Password = _view.Password;
            if (_model.IsLoginCorrect())
                _view.LetUserLogin();
            else
                _view.DontLetUserLogin();

            // В данной форме этот вызов не нужен, однако в общем
            // случае изменение части Модели может привести к изменениям
            // в других ее частях. Поэтому необходимо синхронизировать
            // Представление с новым текущим состоянием Модели.
            UpdateView();
        }

        private void UpdateView()
        {
            _view.UserName = _model.UserName;
            _view.Password = _model.Password;
        }
    }
}
