using ACM.BusinessLogic;

namespace ACM.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer entityToAdd)
        {
            // If this is a new customer, create the customer record
            // determine whether the customer is an existing customer.
            // if not, validate entered customer inforemation
            // if not valid, notify th euser.
            // if valid,
            // open a connection
            // set stored procedure parameters with the customer data
            // call the  save stored procedure.
        }

        public void Update()
        {
            // if Not,
            // request an email address from the user.
            // Open a connection
            // Set stored procedure parameters with the Customer data.
            // call the save stored procedure.
        }
    }
}