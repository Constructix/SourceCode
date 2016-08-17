using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {



            ILog textLog = new TextLog(@"D:\Files\testlogger.txt");
            List<Request> requests = new List<Request>();


            DateTime inputTestDAteTime;

            bool isValid = DateTime.TryParse("2016-08-17T09:52:38+10", out inputTestDAteTime);
            Console.WriteLine(isValid);

            if (isValid)
            {
                DateTimeKind kind = inputTestDAteTime.Kind;
                Console.WriteLine(kind.ToString());

                Console.WriteLine(inputTestDAteTime.ToLocalTime());

            }



            var supplierRequest = new SupplierRequest(textLog)
            {
                Id = "CHERMSIDE_001"
            };

            requests.Add(supplierRequest);


            ILog xmlLog = new XmlLog(@"D:\Files\testXmlLogger.xml");
            var clientRequest = new ClientRequest(xmlLog)
            {
                Id = Guid.NewGuid(),
                ExpiryDate = DateTime.Parse("01/07/2017")
            };

            requests.Add(clientRequest);
            foreach (var currentRequest in requests)
            {
                currentRequest.Log();
            }
        }

       

        private static void Manuscripts()
        {

      




            List<Manuscript> documents = new List<Manuscript>();

            var formattter = new FancyFormatter();

            var faq = new FAQ(formattter)
            {
                Title = "The Bridge Pattern FAQ"
            };
            faq.Questions.Add("What is it", "A Design Pattern");
            faq.Questions.Add("When do we use it", "When you need to separate an abstraction from an implementation");

            documents.Add(faq);

            var book = new Book(formattter)
            {
                Title = "Lots of Patterns",
                Author = "John Sonmez",
                Text = "Blah blah blah"
            };

            documents.Add(book);
            var paper = new TermPaper(formattter)
            {
                Class = "Design Patterns",
                Student = "Joe Noob",
                Text = "Blah blah blah",
                References = "GOF"
            };

            documents.Add(paper);

            foreach (var document in documents)
            {
                document.Print();
            }
        }
    }
}
