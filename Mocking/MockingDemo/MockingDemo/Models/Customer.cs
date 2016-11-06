using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework.Internal;

//using NUnit.Framework;

namespace MockingDemo
{

    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }

    public class Customer : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return $"{LastName},{FirstName}";
        }

        public virtual Address Address { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}