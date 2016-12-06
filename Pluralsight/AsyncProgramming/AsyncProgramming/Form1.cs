using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            label2.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = $"{++counter}";

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var client = new WebClient();
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri("http://www.filipekberg.se/rss/"));
        }


        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            RssText.Text = e.Result;
            button1.Enabled = true;

        }
    }
}
