using System;

namespace MockingDemo
{
    public interface IOrderFactoryInputData
    {
        DateTime Created { get; set; }
        Customer Customer { get; set; }
    }
}