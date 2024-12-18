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

namespace homework3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            TextBox[] textBoxes = { Box1, Box2, Box3, Box4, Box5, Box6, Box7, Box8, Box9 };

            for (int j = 0; j < textBoxes.Length; j++) {
                if (textBoxes[j].Text.Length == 0) { return; }
            }

            double[] matrix = {
                double.Parse(Box1.Text), double.Parse(Box2.Text), double.Parse(Box3.Text),
                double.Parse(Box4.Text), double.Parse(Box5.Text), double.Parse(Box6.Text),
                double.Parse(Box7.Text), double.Parse(Box8.Text), double.Parse(Box9.Text)
            };

            // Получение значений из массива
            double a = matrix[0], b = matrix[1], c = matrix[2];
            double d = matrix[3], e1 = matrix[4], f = matrix[5];
            double g = matrix[6], h = matrix[7], i = matrix[8];

            // Вычисление определителя
            double determinant = a * e1 * i + b * f * g + c * d * h
                                - c * e1 * g - b * d * i - a * f * h;

            Label.Content = determinant.ToString("F2");
        }
    }
}