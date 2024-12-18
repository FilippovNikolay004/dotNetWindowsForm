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

namespace homework2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;

            if (button.Content?.ToString()?.ToLower() == "c") {
                Label.Content = "";
                return;
            }

            if (button.Content?.ToString()?.ToLower() == "ok") {
                int PIN = int.Parse(Label.Content.ToString() ?? "");

                if (PIN == 1234) {
                    MessageBox.Show($"Верно!");
                } else {
                    MessageBox.Show($"Неверно!");
                }

                return;
            }

            Label.Content += button.Content?.ToString();
        }
    }
}