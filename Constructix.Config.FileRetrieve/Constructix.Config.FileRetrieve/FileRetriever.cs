using System.Configuration;

namespace Constructix.Config.FileRetrieve
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