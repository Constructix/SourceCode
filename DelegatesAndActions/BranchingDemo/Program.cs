using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();



        }
    }



    public class Account
    {

        public decimal Balance { get; set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            // deposit money...

        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;

            if (this.IsClosed)
                return;

            // withdraw money....
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
