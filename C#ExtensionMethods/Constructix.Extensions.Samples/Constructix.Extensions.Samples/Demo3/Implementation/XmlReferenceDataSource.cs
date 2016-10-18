using System.Collections.Generic;

namespace Constructix.Extensions.Samples.Demo3
{
    public abstract class XmlDataSource
    {
        public string Name = "XML";
    }

    public class XmlReferenceDataSource : SqlDataSource, IReferenceDataSource
    {
        public IEnumerable<ReferenceDataItem> GetItems()
        {
            return new List<ReferenceDataItem>
            {
                new ReferenceDataItem { Code ="xyz", Description = "from Xml"},
                new ReferenceDataItem { Code ="xyz", Description = "from Xml 2"},
            };
        }
    }
}
