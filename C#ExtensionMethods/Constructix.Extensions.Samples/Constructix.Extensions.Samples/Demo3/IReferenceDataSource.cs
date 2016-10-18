using System.Collections.Generic;

namespace Constructix.Extensions.Samples.Demo3
{
    public interface IReferenceDataSource
    {
        IEnumerable<ReferenceDataItem> GetItems();
    }
}