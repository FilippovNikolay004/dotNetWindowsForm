using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string Operand1
        {
            get { return operand1.Text.Trim(); }
            set { operand1.Text = value; }
        }

        private string Operand2
        {
            get { return operand2.Text.Trim(); }
            set { operand2.Text = value; }
        }

        private string Operation
        {
            get { return operation.SelectedItem.ToString(); }
        }

        private string Result 
        {
            get { return result.Text; }
            set { result.Text = value; } 
        }

        public Form1()
        {
            InitializeComponent();
            operation.Items.Add("+");
            operation.Items.Add("-");
            operation.Items.Add("*");
            operation.Items.Add("/");
            operation.SelectedItem = operation.Items[0];
            try
            {
                StreamReader sr = new StreamReader("Database.txt", Encoding.UTF8);
                if (sr != null)
                    Result = sr.ReadLine();
                sr.Close();
            }
            catch (Exception)
            {

            }         
        }

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            try
            {
                double op1 = Convert.ToDouble(Operand1);
                double op2 = Convert.ToDouble(Operand2);
                StreamWriter sw = new StreamWriter("Database.txt", false);
                switch (Operation)
                {
                    case "+":
                        Result = (op1 + op2).ToString();
                        sw.WriteLine(Result);
                        break;
                    case "-":
                        Result = (op1 - op2).ToString();
                        sw.WriteLine(Result);
                        break;
                    case "*":
                        Result = (op1 * op2).ToString();
                        sw.WriteLine(Result);
                        break;
                    case "/":
                        Result = (op1 / op2).ToString();
                        sw.WriteLine(Result);
                        break;
                }
                sw.Close();
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
