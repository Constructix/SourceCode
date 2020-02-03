namespace WatchListAnalysis.Tests
{
    public class StubWatchListAnalysis :IWatchListAnalysis
    {
        public string [] filesToReturn { get; set; }
        public string[] GetFiles(string folderLocation)
        {
            return filesToReturn;
        }
    }
}