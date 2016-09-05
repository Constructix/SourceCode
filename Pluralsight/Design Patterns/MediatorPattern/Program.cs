using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
           ConcreteMediator chatroom = new ConcreteMediator();


            ConcreteColleague1 col1 = new ConcreteColleague1(chatroom);
            ConcreteColleague2 col2 = new ConcreteColleague2(chatroom);

            chatroom.Colleague1 = col1;
            chatroom.Colleague2 = col2;



            col1.Send("Hello World");
            col2.Send("Testing");



        }
    }
}
