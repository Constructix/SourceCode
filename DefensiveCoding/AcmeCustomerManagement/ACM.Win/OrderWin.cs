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

            var allowSplitOrders = true;
            var customer = new Customer();
            // populate the customer instance
            var customerRepository = new CustomerRepository();
            customerRepository.Add(customer);

            var order = new Order();
            // populate order properties of instance.
            var orderRepository = new OrderRepository();
            orderRepository.Add(order);
            
            var inventoryRepository = new InventoryRepository();
            inventoryRepository.OrderItems(order, allowSplitOrders);

           





        }
    }
}
