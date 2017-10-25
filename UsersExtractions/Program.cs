using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            Dictionary<Guid, Player> dictionary = new Dictionary<Guid, Player>();
            string pattern = "Player #*.* - GUID: *.*";

            Console.WriteLine("Extracting data...");
            const string defaultFolderName = @"D:\RCon";
            const string textFiles = "*.txt";
            string folderName = defaultFolderName;

            if (args.Length == 1)
            {
                var directoryInfo = new System.IO.DirectoryInfo(args[0]);
                if(directoryInfo.Exists)
                    folderName = args[0];
            }
            
            string [] files =  System.IO.Directory.GetFiles(folderName, textFiles);
            GetPlayerConnections(files, pattern, dictionary);
            Console.WriteLine($"{"Name",-30}{"GUID",-32}");
            foreach (KeyValuePair<Guid, Player> keyValuePair in dictionary.OrderBy(x => x.Value.Name))
            {
                Console.WriteLine(
                    $"{keyValuePair.Value.Name,-30} {keyValuePair.Key} Connected: {keyValuePair.Value.Connected}");
            }


            var results = dictionary.Values.OrderByDescending(x => x.Connected).Take(10);

            Console.WriteLine("Top Ten Connections");


            foreach (var result in results)
            {
                Console.WriteLine($"{result.Name} {result.Connected}");
            }
        }

        private static void GetPlayerConnections(string[] files, string pattern, Dictionary<Guid, Player> dictionary)
        {
            foreach (string currentFile in files)
            {
                var contents = System.IO.File.ReadAllText(currentFile);
                MatchCollection _collection = Regex.Matches(contents, pattern);
                foreach (Match match in _collection)
                {
                    UpdateDictionary(dictionary, PlayerBuilder.CreatePlayer(match.Value));
                }
            }
        }

        private static void UpdateDictionary(Dictionary<Guid, Player> dictionary, Player newPlayer)
        {
            if (!dictionary.ContainsKey(newPlayer.Guid))
            {
                dictionary.Add(newPlayer.Guid, newPlayer);
            }
            else
            {
                newPlayer = dictionary[newPlayer.Guid];
                newPlayer.AddConnected();
            }
        }
    }

    public class PlayerBuilder
    {
        public static Player CreatePlayer(string currentLine)
        {
            string playerPattern = @"Player #\d{1,5}";
            string guidPattern = @"- GUID: \w{32}";

            Regex playerRegEx = new Regex(playerPattern, RegexOptions.IgnoreCase);
            Regex guidRegEx = new Regex(guidPattern, RegexOptions.IgnoreCase);

            var playerMatch = playerRegEx.Match(currentLine);
            var guidMatch = guidRegEx.Match(currentLine);

            string guid = guidMatch.Value.Substring(guidMatch.Length - 32);
            string name = currentLine.Substring(playerMatch.Length + 1, guidMatch.Index - playerMatch.Length - 1);
            return new Player(name, guid);
        }
    }

    public class Player
    {
        [Key]
        public Guid Guid { get; private set; }


        public Player(string name, string guid)
        {
            Name = name;
            this.Guid = new Guid(guid);
            Connected = 1;
        }

        public int Connected { get; set; }

        public void AddConnected()
        {
            Connected++;
        }

        public string Name { get; private set; }
    }
}
