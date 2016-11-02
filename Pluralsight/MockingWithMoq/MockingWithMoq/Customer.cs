using System.Net.Mail;

namespace MockingWithMoq
{
    public class Customer
    {
        private string city;
        private string name;

        public Customer(string name, string city)
        {
            this.name = name;
            this.city = city;
        }

        public MailAddress MailAddress { get; set; }
    }
}