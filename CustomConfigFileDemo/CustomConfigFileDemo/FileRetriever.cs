using System.Configuration;

namespace CustomConfigFileDemo
{
    public class FileRetriever
    {
        public static FileRetrieverSection _config = ConfigurationManager.GetSection("fileRetriever") as FileRetrieverSection;

        public static FileElementCollection GetFiles()
        {
            return _config.Files;
        }
    }
}