using Mandelbrot.Business.OperationServices;
using MandelbrotSet.Business;
using MandelbrotSet.Core;
using MandelbrotSet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MandelbrotSet.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task GetPixelsAsync()
        {
            var service = new MandelbrotService(new ActorService(), new MandelbrotSetCalcJobCreator());
            await service.CalculateAsync((int)canvas.ActualHeight, (int)canvas.ActualWidth, 1000, x => Draw(x));
        }

        private void Draw(List<MandelbrotResult> result)
        {
            foreach (var pixel in result)
            {
                AddPixel(pixel.Row, pixel.Column, MapColor(pixel.ColorCode));
            }
        }

        private Color MapColor(int colorCode)
        {
            switch ((MandelbrotColor)colorCode)
            {
                case MandelbrotColor.Black:
                    return Colors.Black;
                case MandelbrotColor.Red:
                    return Colors.Red;
                case MandelbrotColor.Blue:
                    return Colors.Blue;
                case MandelbrotColor.Green:
                    return Colors.Green;
                case MandelbrotColor.Yellow:
                    return Colors.Yellow;
                case MandelbrotColor.Purpel:
                    return Colors.Purple;
                case MandelbrotColor.DeepGreen:
                    return Colors.LimeGreen;
                case MandelbrotColor.DeepRed:
                    return Colors.Aqua;
                case MandelbrotColor.DeepBlue:
                    return Colors.DeepPink;
                case MandelbrotColor.LightGreen:
                    return Colors.LightSeaGreen;
                default:
                    return Colors.Black;
            }
        }

        private void AddPixel(double x, double y, Color color)
        {
            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(color);
            canvas.Children.Add(rec);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();
            await GetPixelsAsync();
            watch.Stop();

            MessageBox.Show(watch.ElapsedMilliseconds + " ms");
        }
    }
}
