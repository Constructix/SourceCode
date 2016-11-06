using System;

namespace MockingDemo
{
    public class Order : BaseEntity<int>
    {
        public DateTime Created { get; set; }

        public virtual Customer Customer { get; set; }
    }
}