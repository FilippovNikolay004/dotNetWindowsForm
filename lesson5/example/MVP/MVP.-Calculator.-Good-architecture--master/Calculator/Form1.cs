using System;
using System.Windows.Forms;

namespace Calculator
{
    // Представление отвечает только за взаимодействие с пользователем
    // Это соответствует принципу единственной обязанности
    public partial class CalcForm : Form, ICalculateView
    {
        #region ICalculateView Implementation
        public string Operand1
        {
            get { return operand1.Text.Trim(); }
            set { operand1.Text = value; }
        }

        public string Operand2
        {
            get { return operand2.Text.Trim(); }
            set { operand2.Text = value; }
        }

        public string Operation
        {
            get { return operation.SelectedItem.ToString(); }
        }

        public string Result 
        {
            get { return result.Text; }
            set { result.Text = value; } 
        }

        // Представление выставляет наружу подписку на происходящие в нем события
        public event EventHandler<EventArgs> CalculateEvent;

        #endregion ICalculateView Implementation

        public CalcForm()
        {
            InitializeComponent();
            operation.Items.Add("+");
            operation.Items.Add("-");
            operation.Items.Add("*");
            operation.Items.Add("/");
            operation.SelectedItem = operation.Items[0];         
        }

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Представление оповещает подписчиков (Презентер) о событии нажатия на кнопку
                CalculateEvent?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Operand1_TextChanged(object sender, EventArgs e)
        {
            Calculate.Enabled = Operand1.Length > 0 && Operand2.Length > 0;
        }
    }
}
