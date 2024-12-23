using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        List <Grid> Array{ get; set; }

        public Window1() {
            InitializeComponent();
            Array = new List <Grid>();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Grid first = new Grid();
            first.Margin = new Thickness(5, 5, 5, 5);
            first.ColumnDefinitions.Add(new ColumnDefinition());
            first.ColumnDefinitions.Add(new ColumnDefinition());
            first.ColumnDefinitions.Add(new ColumnDefinition());

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = RgbaToHex((byte)(255 - alpha.Value), (byte)red.Value, (byte)green.Value, (byte)blue.Value);
            Grid.SetColumn(textBlock1, 0);

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = resultColor.Fill;
            rectangle.Height = 30;
            rectangle.Margin = new Thickness(10, 0, 0, 0);
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.StrokeThickness = 0;
            Grid.SetColumn(rectangle, 1);

            Button button1 = new Button();
            button1.Width = 100;
            button1.Margin = new Thickness(10, 0, 0, 0);
            button1.Content = "Delete";
            button1.Click += Button1_Click;
            Grid.SetColumn(button1, 2);

            first.Children.Add(textBlock1);
            first.Children.Add(rectangle);
            first.Children.Add(button1);

            Array.Add(first);

            listColor.Children.Add(first);

            buttonAdd.IsEnabled = HasColor();
        }

        private void Button1_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            Grid parentGrid = (Grid)button.Parent;

            listColor.Children.Remove(parentGrid);

            buttonAdd.IsEnabled = HasColor();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            Color myColor = Color.FromArgb((byte)(255 - alpha.Value), (byte)red.Value, (byte)green.Value, (byte)blue.Value);
            resultColor.Fill = new SolidColorBrush(myColor);

            buttonAdd.IsEnabled = HasColor();
        }

        private bool HasColor() {
            foreach (var element in listColor.Children) {
                if (element is Grid grid) {
                    foreach (var gridChild in grid.Children) {
                        if (gridChild is TextBlock textBlock) {
                            if(textBlock.Text == RgbaToHex((byte)(255 - alpha.Value), (byte)red.Value, (byte)green.Value, (byte)blue.Value)) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private string RgbaToHex(int a, int r, int g, int b) {
            // Преобразуем значения в формат HEX (2 символа для каждой компоненты)
            string hex = "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");

            // Если альфа-канал не равен 255 (полная прозрачность), добавляем его в HEX
            if (a < 255) { hex += a.ToString("X2"); }

            return hex;
        }

    }
}