using System;

namespace DelegatesAndActionDemo
{
    public class DelegateDemo
    {

        public static void Main()
        {
            DisplayMessage messageTarget;


            messageTarget = ShowMessageViaFunction;
            messageTarget += Console.WriteLine;

            messageTarget("Hello World");


        }


        public static void ShowMessageViaFunction(string message)
        {
            Console.WriteLine(message);
        }
    }
}