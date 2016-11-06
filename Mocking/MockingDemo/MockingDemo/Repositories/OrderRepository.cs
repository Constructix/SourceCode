namespace MockingDemo
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(ConstructixServicesContext context): base(context)
        {
            
        }

        public override void Add(Order entityToAdd)
        {
            _context.Orders.Add(entityToAdd);
            _context.SaveChanges();
        }

        public override void Remove(Order entityToRemove)
        {
            _context.Orders.Remove(entityToRemove);
            _context.SaveChanges();
        }
    }
}