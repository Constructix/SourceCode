using System.Collections.Generic;
using System.Linq;

namespace Constructix.Extensions.Samples.Demo3
{
    public static class IReferenceDataSourceExtensions
    {
        public static IEnumerable<ReferenceDataItem> GetItemsByCode(this IReferenceDataSource source, string code)
        {
            return source.GetItems().Where(x=>x.Code.Equals(code));
        }
    }
}