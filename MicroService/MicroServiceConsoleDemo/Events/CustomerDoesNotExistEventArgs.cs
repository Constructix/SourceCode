using System;

namespace ConsoleApp1.Events
{
    public class CustomerDoesNotExistEventArgs : EventArgs
    {
        public DateTime Created { get; set; }
        public string Message {get;}
        public string Email { get; }
        public CustomerDoesNotExistEventArgs()
        {
            Created = DateTime.Now;
            Message = "Customer does not exist on record.";
        }

        public CustomerDoesNotExistEventArgs(string email)
        {
            Created = DateTime.Now;
            Message = $"{email} does not exist on record.";
            Email = email;
        }
        
    }
}