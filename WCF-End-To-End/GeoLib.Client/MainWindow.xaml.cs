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
using GeoLib.Contracts;
using GeoLib.Proxies;

namespace GeoLib.Client
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                GeoClient proxy = new GeoClient();
                ZipCodeData data = proxy.GetZipInfo(textBox.Text);
                if (data != null)
                {
                    StringBuilder result = new StringBuilder();
                    result.AppendLine(data.City);
                    result.AppendLine(data.State);

                    lblResultGetInfo.Content = result.ToString();
                }
                else
                {
                    lblResultGetInfo.Content = "No Data found.";
                }
                proxy.Close();
            }
        }
    }
}
