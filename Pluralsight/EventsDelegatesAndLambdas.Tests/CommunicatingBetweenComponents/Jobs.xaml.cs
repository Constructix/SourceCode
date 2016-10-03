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

namespace CommunicatingBetweenComponents
{
    /// <summary>
    /// Interaction logic for Jobs.xaml
    /// </summary>
    public partial class Jobs : UserControl
    {
        private List<Job> _jobs = new List<Job>()
        {
            new Job
            {
                Id = 1,
                Title = "Area 1 Maintenance"
                //StartDate = DateTime.Parse("01/06/2016"),
                //EndDate = DateTime.Parse("10/06/2016")
            },
            new Job
            {
                Id = 2,
                Title = "Edge Park"
                //StartDate = DateTime.Parse("11/06/2016"),
                //EndDate = DateTime.Parse("12/06/2016")
            },
            new Job
            {
                Id = 3,
                Title = "Paint Benches"
                //StartDate = DateTime.Parse("15/06/2016"),
                //EndDate = DateTime.Parse("18/06/2016")
            },
            new Job
            {
                Id = 4,
                Title = "Build New Wall"
                //StartDate = DateTime.Parse("20/06/2016"),
                //EndDate = DateTime.Parse("25/06/2016")
            },

        };

        
        public Jobs()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            JobsCombBox.ItemsSource = _jobs;
        }

        private void JobsCombBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mediator.GetInstance().OnJobChanged(this, (Job) JobsCombBox.SelectedItem);
        }
    }
}
