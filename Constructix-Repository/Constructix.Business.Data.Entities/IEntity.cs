using System;

namespace Constructix.Business.Data.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime Created { get; set; }
    }
}