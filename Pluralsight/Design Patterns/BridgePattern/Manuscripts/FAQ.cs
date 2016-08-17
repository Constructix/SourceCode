using System;
using System.Collections.Generic;

namespace BridgePattern
{
    public class FAQ : Manuscript
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }
       
        public FAQ(IFormatter formatter) :base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

       

        public override  void Print()
        {
            Console.WriteLine(formatter.Format("Title",Title));
            foreach (KeyValuePair<string, string> keyValuePair in Questions)
            {
                Console.WriteLine(formatter.Format(keyValuePair.Key, keyValuePair.Value));
            }
            Console.WriteLine();
        }
    }
}