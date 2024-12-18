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

namespace practice {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            red.Minimum = 0;
            red.Maximum = 255;

            green.Minimum = 0;
            green.Maximum = 255;

            blue.Minimum = 0;
            blue.Maximum = 255;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            Color myColor = Color.FromRgb((byte)red.Value, (byte)green.Value, (byte)blue.Value);
            Background = new SolidColorBrush(myColor);
        }
    }
}