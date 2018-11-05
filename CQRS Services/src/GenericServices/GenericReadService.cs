using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GenericServices.Data;
using GenericServices.Services.Models;

namespace GenericServices
{
    public class GenericReadService<T, K> : IReadService<T, K> where T : IEntity<K>
    {
        private List<T> items { get; set; }

        public GenericReadService(List<T> items)
        {
            this.items = items;
        }

      
        public virtual IEntity<K> Get(K id)
        {
            return items.FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual IQueryable<IEntity<K>> GetAll()
        {
            return null;
        }
    }

    public class CustomerReadService
    {
        private readonly CustomersContext database = new CustomersContext();

       
        public CustomerReadService(List<Customer> items) 
        {
        }

        public  CustomerDTO Get(int id)
        {
            CustomerDTO customerDTO = database.Customers.Find(id);
            if (customerDTO != null)
            {
                return customerDTO;
            }
            return null;
        }

        public IQueryable<CustomerDTO> GetAll()
        {
            return database.Customers.AsQueryable();
        }
    }

    public class GenericWriteService<T, K > : IWriteService<T, K> where T : IEntity<K>
    {
        public virtual void Write(T itemToAdd)
        {
           
        }
    }

    public class CustomerWriteService : GenericWriteService<Customer,int>
    {
        private readonly CustomersContext database = new CustomersContext();

        public override void Write(Customer itemToAdd)
        {
            CustomerDTO customerDTO = new CustomerDTO();
            customerDTO.FirstName = itemToAdd.FirstName;
            customerDTO.LastName = itemToAdd.LastName;

            database.Customers.Add(customerDTO);
            database.SaveChanges();
        }
    }
}