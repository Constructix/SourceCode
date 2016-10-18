using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // If this is a new customer, create the customer record
            // determine whether the customer is an existing customer.
            // if not, validate entered customer inforemation
            // if not valid, notify th euser.
            // if valid,
            // open a connection
            // set stored procedure parameters with the customer data
            // call the  save stored procedure.


            // create the order for the customer
            // for each item ordered,
            // validate teh entered information
            // if not valid, notify the user
            // if valid, 
            // open a connection
            // set stored procedure parameters with the order data.
            // call the save stored procedure.
        }
    }
}
