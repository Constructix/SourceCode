using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryDesignPattern
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
        DateTime Created { get; set; }
    }
}