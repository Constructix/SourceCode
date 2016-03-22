using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
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
using GeoLib.Services;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ServiceHost _hostGeoManager = null;

        public MainWindow()
        {
            InitializeComponent();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = !btnStart.IsEnabled;


            Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId;
        }

        private void EnableDisableButtons()
        {
            btnStart.IsEnabled = !btnStart.IsEnabled;
            btnStop.IsEnabled = !btnStart.IsEnabled;
        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            _hostGeoManager = new ServiceHost(typeof(GeoManager));

            _hostGeoManager.Open();
            lblServiceNotice.Content = "Service is running.";
            EnableDisableButtons();
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {

            _hostGeoManager.Close();
            EnableDisableButtons();
            lblServiceNotice.Content = "Service is not running.";
        }
    }
}
