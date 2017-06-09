using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACM.BusinessLogic;
using ACM.Controllers;
using ACM.Repository;


namespace ACM.Win
{
    public partial class OrderWin : Form
    {
        public OrderWin()
        {
            InitializeComponent();
        }

        private void OrderWin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaceOrder();
        }

        private void PlaceOrder()
        {
            var customer = new Customer(); // populate the customer instance
            var order = new Order(); // populate order properties of instance.
            var payment = new Payment();
            // populate the payment instance.
            new OrderController().PlaceOrder(customer, order, payment,allowSplitOrders:false,emailReceipt:true);
        }
    }
}
