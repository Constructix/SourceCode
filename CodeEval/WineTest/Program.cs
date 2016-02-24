using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Program
{
    static int Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Usage: WineTest [FileName]");
            return 1;
        }

        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (reader.Peek() != -1)
            {
                string currentLine = string.Empty;
                if (!string.IsNullOrEmpty(currentLine = reader.ReadLine()))
                {
                    string wine = currentLine.Split(new char[] { '|' })[0].Trim();
                    string key = currentLine.Split(new char[] { '|' })[1].Trim();


                    string[] refinedWineName = wine.Split(new char[] { ' ' });
                    List<string> resultSet = new List<string>();
                    if (refinedWineName.Any(wineName => wineName.Length < 2 || wineName.Length > 15))
                    {
                        return 1;
                    }
                    if (key.Length > 5 || key.Length < 0)
                    {

                        return 1;
                    }

                    if (key.Length <= 2)
                    {
                        foreach (string currentWine in refinedWineName)
                        {
                            bool exists = currentWine.Contains(key);
                            if (exists)
                            {
                                StringBuilder builder = new StringBuilder();
                                foreach (var s in refinedWineName)
                                {
                                    builder.AppendFormat("{0} ", s);
                                }
                                builder = builder.Remove(builder.Length - 1, 1);
                                resultSet.Add(builder.ToString());
                            }
                        }
                    }
                    else
                    {
                        char[] keys = key.ToCharArray();
                        for (int index = 1; index < keys.Length; index++)
                        {
                            StringBuilder builder = new StringBuilder();
                            builder.AppendFormat("{0}{1}", keys[index - 1], keys[index]);

                            foreach (string currentWine in refinedWineName)
                            {


                                bool exists = currentWine.Contains(builder.ToString());
                                if (exists)
                                    resultSet.Add(wine);
                            }
                        }
                    }
                    Console.WriteLine(resultSet.Any() ? resultSet.FirstOrDefault() : "False");
                }
            }
            return 0;
        }
    }
}

