using ACM.BusinessLogic;

namespace ACM.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public void Add(Order entityToAdd)
        {
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