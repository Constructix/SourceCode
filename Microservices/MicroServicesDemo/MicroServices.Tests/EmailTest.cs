using MicroServices.DTO;
using MicroServices.MailMessages;
using MicroServicesDemo;
using Xunit;

namespace MicroServices.Tests
{
    public class EmailTest
    {
        [Fact]
        public void SendEmail()
        {
            MailOrder   mo = new MailOrder();
            mo.Email = "r_jones@constructix.com.au";
            mo.RecipientName = "r_jones@constructix.com.au";
            MailMessageService svc = new MailMessageService();
            svc.Process(mo);
        }
    }
}