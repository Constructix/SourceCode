using System.Configuration;

namespace CustomConfigFileDemo
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