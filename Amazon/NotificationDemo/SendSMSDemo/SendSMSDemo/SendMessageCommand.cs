using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace SendSMSDemo
{
    public class SendMessageCommand
    {
        public async Task Execute(SMSMessage message)
        {
            AmazonSimpleNotificationServiceClient client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.APSoutheast2);

            PublishRequest request = new PublishRequest();
            request.Message = message.Contents;


            request.PhoneNumber = message.Number;

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {

                
                PublishResponse response = await client.PublishAsync(request);
                Console.WriteLine($"Message Id : {response.MessageId} {response.HttpStatusCode}");
            }
            else
            {
                Console.WriteLine(Constants.Messages.MobileNumberMissingMessage);
            }
        }
    }
}