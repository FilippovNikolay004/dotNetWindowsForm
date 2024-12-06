using System;

namespace Calculator
{
    public class CalculatePresenter
    {
        private readonly IModel _model;
        private readonly ICalculateView _view;

        // Принцип инверсии зависимостей
        public CalculatePresenter(IModel model, ICalculateView view)
        {
            _model = model;
            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.CalculateEvent += new EventHandler<EventArgs>(OnCalculate);
            _model.Load();
            _view.Result = _model.Result;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            try
            {
                // Презентер реализует логику приложения и изменяет модель
                double op1 = Convert.ToDouble(_view.Operand1);
                double op2 = Convert.ToDouble(_view.Operand2);
                switch (_view.Operation)
                {
                    case "+":
                        _model.Result = (op1 + op2).ToString();
                        break;
                    case "-":
                        _model.Result = (op1 - op2).ToString();
                        break;
                    case "*":
                        _model.Result = (op1 * op2).ToString();
                         break;
                    case "/":
                        _model.Result = (op1 / op2).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           // Необходимо синхронизировать Представление с новым текущим состоянием Модели
            UpdateView();
        }

        private void UpdateView()
        {
            _model.Save();
            _view.Result = _model.Result;
        }
    }
}
