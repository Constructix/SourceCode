using System.Configuration;

namespace Constructix.Config.FileRetrieve
{
    public class FileRetrieverSection : ConfigurationSection
    {
        [ConfigurationProperty("files")]
        public FileElementCollection Files
        {
            get { return (FileElementCollection) this["files"]; }
        }
    }
}