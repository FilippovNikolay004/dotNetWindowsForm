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


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       List <StackPanel> Array{ get; set; }

        public Window1()
        {
            InitializeComponent();
            Array = new List <StackPanel> ();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel first;
            first = new StackPanel();
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "Hello";
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.Blue);
            rectangle.Width = 100;
            rectangle.Height = 30;
            rectangle.Margin = new Thickness(10, 0, 0, 0);

            rectangle.StrokeThickness = 0;

            Button button1 = new Button();
            button1.Width = 100;
            button1.Margin = new Thickness(10, 0, 0, 0);
            button1.Content = "Delete";

            first.Orientation = Orientation.Horizontal;
            first.Children.Add(textBlock1);
            first.Children.Add(rectangle);
            first.Children.Add(button1);
            Array.Add(first);

            listColor.Children.Add(first);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {


            Color myColor = Color.FromRgb((byte)red.Value, (byte)green.Value, (byte)blue.Value);
            resultColor.Fill = new SolidColorBrush(myColor);
        }
    }
}
