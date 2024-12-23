using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

public delegate string MathOperation(string a, string b);

namespace homework2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string expression { get; set; } = string.Empty;
        string[] arrayOfExpression { get; set; } = { };
        bool isAddOperator { get; set; } = true;
        bool isClear {  get; set; } = false;


        public MainWindow() {
            InitializeComponent();
        }

        private void Click_Number(object sender, RoutedEventArgs e) {
            Button buttonNumber = (Button)sender;

            if (isClear) {
                label1.Content = label2.Content = "";
                arrayOfExpression = [];
                isClear = false;
            }

            if (label2.Content.ToString() == "0" && 
                buttonNumber.Content.ToString() != ",") {
                
                return;
            }

            isAddOperator = true;
            label2.Content += buttonNumber.Content.ToString();

            ParseExpression();
        }
        private void Click_DecimalSeparator(object sender, RoutedEventArgs e) {
            ParseExpression();

            if (arrayOfExpression.Length % 2 == 0) {
                return;
            }

            if (arrayOfExpression.Last()?.IndexOf(",") != -1) {
                return;
            }

            if (arrayOfExpression.Last()?.Length != 0) {
                label2.Content += ",";
            }
            isAddOperator = false;

            ParseExpression();
        }
        private void ParseExpression() {
            expression = label2.Content.ToString() ?? "";

            expression = expression.Replace("+", "_+_");
            expression = expression.Replace("-", "_-_");
            expression = expression.Replace("*", "_*_");
            expression = expression.Replace("/", "_/_");

            arrayOfExpression =
                expression.Split('_', StringSplitOptions.RemoveEmptyEntries);
        }

        private void Click_ClearAll(object sender, RoutedEventArgs e) {
            label1.Content = label2.Content = "";
            arrayOfExpression = [];
        }
        
        private void Click_ClearCurrentNumber(object sender, RoutedEventArgs e) {
            label2.Content = "";
            arrayOfExpression = [];
        }

        private void Click_Operator(object sender, RoutedEventArgs e) {
            Button buttonOperator = (Button)sender;

            if (arrayOfExpression.Last()[arrayOfExpression.Last().Length - 1].ToString() == ",") {
                return;
            }

            if (!isAddOperator) {
                return;
            }

            label2.Content += buttonOperator.Content.ToString();
        }
        private void Click_DelLastSymbol(object sender, RoutedEventArgs e) {
            string temp = label2.Content.ToString()??"";

            if (temp.Length == 0) { return; }
            label2.Content = temp.Remove(temp.Length - 1);
        }


        private void Click_Result(object sender, RoutedEventArgs e) {
            PerformOperation("*", Multi);
            PerformOperation("/", Div);
            PerformOperation("+", Sum);
            PerformOperation("-", Deff);

            label1.Content = label2.Content;
            label2.Content = arrayOfExpression[0].ToString();
        }

        private void PerformOperation(string operation, MathOperation mathOperation) {
            for (int i = 0; i < arrayOfExpression.Length && Array.IndexOf(arrayOfExpression, operation) != -1; i++) {
                if (arrayOfExpression[i] == operation) {
                    arrayOfExpression[i] = mathOperation(arrayOfExpression[i - 1], arrayOfExpression[i + 1]);

                    arrayOfExpression[i - 1] = "_";
                    arrayOfExpression[i + 1] = "_";
                }
            }
            arrayOfExpression = arrayOfExpression.Where(item => item != "_").ToArray();
        }
        private string Sum(string sum, string value) {
            return (double.Parse(sum) + double.Parse(value)).ToString();
        }
        private string Deff(string sum, string value) {
            return (double.Parse(sum) - double.Parse(value)).ToString();
        }
        private string Multi(string sum, string value) {
            return (double.Parse(sum) * double.Parse(value)).ToString();
        }
        private string Div(string sum, string value) {
            if (value == "0") { isClear = true; return "Деление на ноль невозможно"; }

            return (double.Parse(sum) / double.Parse(value)).ToString();
        }
    }
}