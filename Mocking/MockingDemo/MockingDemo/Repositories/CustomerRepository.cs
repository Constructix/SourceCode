namespace MockingDemo
{
    public class CustomerRepository : IRepository<Customer>
    {
        private ConstructixServicesContext _context;

        public CustomerRepository()
        {
            _context = new ConstructixServicesContext();
        }

        public CustomerRepository(ConstructixServicesContext context)
        {
            _context = context;
        }


        //List<Customer> _customers = new List<Customer>();
        public void Add(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }

        public void Remove(Customer entityToRemove)
        {
            _context.Customers.Remove(entityToRemove);
            _context.SaveChanges();
        }
    }
}