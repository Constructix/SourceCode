using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace SendSMSDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AmazonSimpleNotificationServiceClient client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.APSoutheast2);

            PublishRequest request = new PublishRequest();
            request.Message = "Sending SMS via AWS";
            request.Subject = "Sending SMS-AWS";

            request.PhoneNumber = string.Empty;

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                PublishResponse response = await client.PublishAsync(request);
                Console.WriteLine($"Message Id : {response.MessageId} {response.HttpStatusCode}");
            }
            else
            {
                Console.WriteLine("Did not send SMS. Mobile number has not been supplied.");
            }



        }
    }
}
