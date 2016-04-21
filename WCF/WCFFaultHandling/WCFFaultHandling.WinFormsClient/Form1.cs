using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFFaultHandling.Contracts;
using WCFFaultHandling.Proxies;

namespace WCFFaultHandling.WinFormsClient
{
    public partial class Form1 : Form
    {
        private Account _userAccount;


        public Form1()
        {
            InitializeComponent();
            InitialiseDataGridViewControl();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load List view control


            MerchantServiceClient client = new MerchantServiceClient();

            List<Product> products = client.GetProducts();


            listBox1.ValueMember = "Id";
            listBox1.DisplayMember = "Name";
            this.listBox1.DataSource = products;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get order items.
            Order newOrder = new Order { Id = Guid.NewGuid(),
                            OrderItems = GetOrderItems(),
                            Account = _userAccount};
            
            
           MerchantServiceClient client = new MerchantServiceClient();

            try
            {
                var result = client.SubmitOrder(newOrder);

                textBox2.AppendText(string.Format("Id: {0} Status : {1}{2}", result.Id.ToString(), result.Status, Environment.NewLine));
                dgvSelectedProducts.Rows.Clear();
            }
            catch (FaultException<ArgumentException> ex )
            {

                MessageBox.Show(string.Format($"Message: {ex.Message}{Environment.NewLine}Detail: {ex.Detail.Message}"), "WCF Exception Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            client.Close();
        }

        private List<OrderItem> GetOrderItems()
        {

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (DataGridViewRow currentRow in dgvSelectedProducts.Rows)
            {
                OrderItem currentOrderItem = currentRow.Tag as OrderItem;
                orderItems.Add(currentOrderItem);
            }
            return orderItems;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product selectedProduct                             = listBox1.SelectedItem as Product;
            OrderItem newOrderItem                              = new OrderItem {SelectedProduct = selectedProduct,
                                                                                Quantity = QuantityRequired()};

            int rowIndex                                        = dgvSelectedProducts.Rows.Add();
            dgvSelectedProducts.Tag                             = newOrderItem;
            dgvSelectedProducts.Rows[rowIndex].Cells[0].Value   = newOrderItem.SelectedProduct.Name;
            dgvSelectedProducts.Rows[rowIndex].Cells[1].Value   = newOrderItem.Quantity;

            textBox1.Clear();
        }

        private int QuantityRequired()
        {
            int quantity = 0;

            int.TryParse(textBox1.Text, out quantity);
            return quantity;
        }


        private void InitialiseDataGridViewControl()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn {Name = "Product", HeaderText = "Product", ValueType = typeof (string)},
                new DataGridViewTextBoxColumn {Name = "Quantity", HeaderText = "Quantity", ValueType = typeof (int)},
            };

            this.dgvSelectedProducts.Columns.AddRange(columns.ToArray());
            this.dgvSelectedProducts.AllowUserToAddRows = false;
            this.dgvSelectedProducts.RowHeadersVisible = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < dgvSelectedProducts.SelectedRows.Count; index++)
            {
                DataGridViewRow selectedRow = dgvSelectedProducts.SelectedRows[index];
                dgvSelectedProducts.Rows.Remove(selectedRow);    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            WCFFaultHandling.Proxies.MerchantServiceClient client = new MerchantServiceClient();
            label3.Text = client.GetClientId(txtEmail.Text);
            _userAccount = client.GetAccount(label3.Text);
            label4.Text = $"{_userAccount.FirstName} {_userAccount.LastName}";
            client.Close();
        }
    }
}
