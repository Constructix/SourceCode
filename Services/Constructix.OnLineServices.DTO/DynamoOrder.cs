using System;
using Amazon.DynamoDBv2.DataModel;

namespace Constructix.OnLineServices.DTO
{
    [DynamoDBTable("Orders")]
    public class DynamoOrder
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        [DynamoDBRangeKey]
        public string SortKey { get; set; }
        [DynamoDBProperty]
        public string Body { get; set; }
        [DynamoDBProperty]
        public string OrderStatus { get; set; }

        public DynamoOrder()
        {
            
        }
        public DynamoOrder(Guid id, string sortKey, string body, string orderStatus)
        {
            Id = id;
            SortKey = sortKey;
            Body = body;
            OrderStatus = orderStatus;
        }
    }
}