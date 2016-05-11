using System;

namespace Constructix.Core.Contracts.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime Created { get; set; }
    }


}