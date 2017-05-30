// Event Aggregator Pattern
using System;

public static class ConsoleMain
{
    public static void Main()
    {
        Console.WriteLine("Hello");

        IEventAggregator Aggregator = new SimpleEventAggregator();
        
        Order newOrder=  new Order();


        Aggregator.Publish(new OrderSelected { Order = newOrder });


        
    }
}

public class SimpleEventAggregator : IEventAggregator
{



    public void Subscribe(object subscriber)
    {

    }

    public void Publish<TEvent>(TEvent eventToPublish)
    {

    }
    
}


public interface IEventAggregator
{
    void Subscribe(object subscriber);
    void Publish<TEvent>(TEvent eventToPublish);
}

public class OrderCreated
{
    public Order Order {get;set;}
}

public class OrderSelected
{
    public Order Order {get;set;}

}

public class OrderSaved
{
    public Order Order {get;set;}
}

public class Order
{

}
