using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Constructix.OnLineServices.Domain;

namespace Constructix.OnLineServices.DTO.SqlServer
{

    public interface IOrder<T>
    {
        T Id { get; set; }
    }
    public class SqlOrder : IOrder<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public SqlOrderStatus Status { get; set; }


    }

    public class SqlOrderStatus 
    {
    }
}
