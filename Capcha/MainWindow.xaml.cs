using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capcha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static Random random = new Random();
        public static int countSymbol = 6;
        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            countSymbol = random.Next(5, 8);
            UpdateCapcha();
        }
        public void GenerateSymbol()
        {
            string alp = "1234567890ABCDEFGHIJKLNOPQRSTUVWXYZ";
            for(int i = 0; i < countSymbol; i++)
            {
                string symbol = alp.ElementAt(random.Next(0, alp.Length)).ToString();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = symbol;
                textBlock.FontSize = random.Next(10, 20);
                textBlock.RenderTransform = new RotateTransform(random.Next(-45, 45));
                textBlock.Margin = new Thickness(10, 0, 10, 0);
                Stack.Children.Add(textBlock);
            }
        }
        public void GenerateNoise(int noise)
        {
            for (int i = 0; i< noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256)));
                ellipse.Height = ellipse.Width = random.Next(20, 50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, random.Next(100, 300));
                Canvas.SetTop(ellipse, random.Next(100, 200));
            }

            for (int i = 0; i < noise; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256)));
                rectangle.Height = rectangle.Width = random.Next(20, 50);
                canvas.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, random.Next(100, 300));
                Canvas.SetTop(rectangle, random.Next(100, 200));

            }
        }
        public void UpdateCapcha()
        {
            Stack.Children.Clear();
            canvas.Children.Clear();
            GenerateSymbol();
            GenerateNoise(100);
        }
    }
}
