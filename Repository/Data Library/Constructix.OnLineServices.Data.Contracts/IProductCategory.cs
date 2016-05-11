using System;
using Constructix.Core.Contracts;
using Constructix.Core.Contracts.Data;

namespace Constructix.OnLineServices.Data.Contracts
{
    public interface IProductCategory: IEntity<int>
    {
        string Name { get; set; }
        DateTime? RemovedOn { get; set; }
    }



}