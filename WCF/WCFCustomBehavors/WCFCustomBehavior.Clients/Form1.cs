using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WCFCustomBehaviors.Contracts;
using WCFCustomBehaviors.Proxies;

namespace WCFCustomBehaviors.Clients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MerchantServiceClient client  = new MerchantServiceClient();

            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add( new OrderItem() {   Quantity =  12,
                                                Product = new Product { Id = 1, Name = "90x90 Post", UnitPrice = 23.44m} });
            Order newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Account = new Account {Email = "r_jones@constructix.com.au", FirstName = "Richard", LastName = "Jones"},
                OrderItems =   orderItems
            };


            var result = client.SubmitOrder(newOrder);

            textBox1.AppendText(string.Format("Status: {0}{1}Last service call was made: {2}{3}", result.Status, Environment.NewLine, DateTime.Now.ToString(), Environment.NewLine));
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
