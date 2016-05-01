using System.ComponentModel.DataAnnotations;

namespace StrayaGaming.Contracts
{
    public interface IEntity<T> 
    {
        [Key]
        T Id { get; set; }
    }
}