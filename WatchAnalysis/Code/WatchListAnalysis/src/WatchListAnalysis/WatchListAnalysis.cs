using System.IO;

namespace WatchListAnalysis
{
    public class WatchListAnalysis : IWatchListAnalysis
    {
        public string[] GetFiles(string folderLocation)
        {
            return Directory.GetFiles(folderLocation, "*.txt");
        }
    }
}