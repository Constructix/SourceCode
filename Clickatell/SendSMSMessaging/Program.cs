using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SendSMSMessaging
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Sending SMS Messages Demostration");
            Console.WriteLine(new string('-', 80));

            HttpClient client = new HttpClient();

            UriBuilder builder = new UriBuilder(new Uri("https://platform.clickatell.com/messages/http/send"));
            builder.Port = -1;
            


            var query = new Dictionary<string, string>
            {
                ["apiKey"] = "",
                ["to"] = "610437291575",
                ["content"] =  "Thanks for choosing Constructix Online Services.Your Delivery is on its way to 11 Carbine Court."
            };

            StringBuilder strBuilder =new StringBuilder();
            var str = "?";
            foreach (KeyValuePair<string, string> keyValuePair in query)
            {
                strBuilder = strBuilder.Append(str + keyValuePair.Key + "=" +  keyValuePair.Value);
                str = "&";
            }


            builder.Query = strBuilder.ToString();

            

            Console.WriteLine(builder.ToString());

            var response = await client.GetStringAsync(builder.ToString());


            Console.WriteLine(response);
            await File.WriteAllTextAsync(@"D:\Development\GitHub\Clickatell\SendSMSMessaging\DataFiles\Response.json", response);
            var messageResponse = JsonConvert.DeserializeObject<MessageResponse>(response);
            if (messageResponse != null)
            {
                foreach (var messageResponseMessage in messageResponse.Messages)
                {
                    Console.WriteLine(messageResponseMessage.Accepted);
                }
            }
        }
    }

    public class MessageResponse
    {
        public List<Message> Messages { get; set; }
        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }

        public MessageResponse()
        {
            
        }

        public MessageResponse(List<Message> messages, string errorCode, string error, string errorDescription)
        {
            Messages = messages;
            ErrorCode = errorCode;
            Error = error;
            ErrorDescription = errorDescription;
        }
    }

    public class Message
    {
        public Guid ApiMessageId { get; set; }
        public bool Accepted { get; set; }
        public string To { get; set; }
        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }

        public Message()
        {
            
        }

        public Message(Guid apiMessageId, bool accepted, string to, string errorCode, string error, string errorDescription)
        {
            ApiMessageId = apiMessageId;
            Accepted = accepted;
            To = to;
            ErrorCode = errorCode;
            Error = error;
            ErrorDescription = errorDescription;
        }


    }

}
