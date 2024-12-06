using System;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CalcForm form = new CalcForm();
            IModel model = new Model();
            CalculatePresenter presenter = new CalculatePresenter(model, form);
            Application.Run(form);
        }
    }
}
