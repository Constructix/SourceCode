using System.Collections.Generic;
using Constructix.Extensions.Samples.Demo3;

namespace Constructix.Extensions.Samples.Demo4
{
    public static class IReferenceDataSourceCollectionExtensions
    {

        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IReferenceDataSource[] sources, string code)
        {
            var items = new List<ReferenceDataItem>();
            foreach (var source in sources)
            {
                items.AddRange(source.GetItemsByCode(code));
            }
            return items;   
        }
    }
}