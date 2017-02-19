using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello World";


            string response1 = GetHash(message);
            Console.WriteLine(response1);

            var response2 = GetHash("Hello World1");
            Console.WriteLine(response2);


            StringComparer comparer = StringComparer.CurrentCultureIgnoreCase;

            Console.WriteLine(comparer.Compare(response1, response2) == 0? "Strings are the same": "Strings are different");
        }

        private static string GetHash(string message)
        {
            using (MD5 md5Hash = new MD5Cng())
            {
                byte[] messageAsBytes = Encoding.ASCII.GetBytes(message);
                byte[] computedBytes = md5Hash.ComputeHash(messageAsBytes);


                StringBuilder builder = new StringBuilder();

                foreach (byte t in computedBytes)
                {
                    builder.Append(t.ToString("x2"));
                }


                return builder.ToString();
            }
        }
    }
}
