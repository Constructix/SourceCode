using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Models.Interfaces
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }

        DateTime Created { get; set; }

        DateTime LastModified {get; set; }
    }

}
