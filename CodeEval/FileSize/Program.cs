using System;
using System.IO;
class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: FileSize [FileName]");
            return 1;
        }

        using (FileStream fs = new FileStream(args[0], FileMode.Open))
        {
            Console.WriteLine(fs.Length);
        }
        return 0;



    }
}

