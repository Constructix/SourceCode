using ACM.BusinessLogic;

namespace ACM.Repository
{
    public class InventoryRepository : IRepository<Inventory>
    {
        public void Add(Inventory entityToAdd)
        {
            throw new System.NotImplementedException();
        }
        public void OrderItems(Order order, bool allowSplitOrders)
        {
            // -- Order the items for inventory--
            // for each item ordered,
            // Locate the item in inventory
            // if no longer available, notify the user,
            // If any items are back ordered and
            // the customer does not want split orders.
            // notify the user.
            // if the Item is available,
            // decrement the quantity remaining.
            // Open the connection
            // set stored procedure parameters with the inventory data.
            // call the save stored procedure.
        }
    }
}