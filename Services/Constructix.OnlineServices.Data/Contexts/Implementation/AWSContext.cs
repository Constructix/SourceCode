using Amazon.DynamoDBv2.DataModel;

namespace Constructix.OnlineServices.Data.Contexts
{
    public class AWSContext : IContext<DynamoDBContext>
    {
        public DynamoDBContext Value { get; set; }

        public AWSContext()
        {
            
        }

        public AWSContext(DynamoDBContext value)
        {
            Value = value;
        }
    }
}