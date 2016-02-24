using System;

namespace CommandDesignPattern
{
    public interface IReceiver
    {
        void Action();
    }


    public class Receiver : IReceiver
    {
        public string Message { get; set; }
        public void Action()
        {
            Console.WriteLine($"{Message}");
        }
    }

    public class UpperCaseReceiver : IReceiver
    {
        public string Message { get; set; }
        public void Action()
        {
            Console.WriteLine($"{Message.ToUpper()}");
        }


    }
}