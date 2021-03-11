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
using System.Windows.Threading;

namespace BlinkerApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStarBlink_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void BtnStopBlink_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
