using System.Configuration;
using System.Net.Mail;
using MicroServices.DTO;
using MicroServicesDemo;

namespace MicroServices.MailMessages
{
    public class MailMessageService : BaseMicroService<MailOrder>
    {
        private string MailServer
        {
            get
            {
                var server =  ConfigurationManager.AppSettings["mailServer"];
                return server;
            }
        }

        private int PortNumber
        {
            get
            {
                int portNumber;
                int.TryParse(ConfigurationManager.AppSettings["mailServerPort"], out portNumber);
                return portNumber;
            }
        }
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public ServiceStatus Status { get; set; }
        public void Process(MailOrder instance)
        {
            MailMessage msg = new MailMessage();
            msg.From =new MailAddress("admin@constructix.com.au");
            msg.To.Add("r_jones@constructix.com.au");

            msg.Subject = "Order has been processed.";
            msg.Body = "Thank you for your order.";

            SmtpClient client = new SmtpClient(MailServer,PortNumber);
            client.Send(msg);
        }
    }
}