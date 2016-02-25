using System.Configuration;

namespace Constructix.Config.FileRetrieve
{


    public class FileElement : ConfigurationElement
    {

        private const string NameConfigurationProperty = "name";
        private const string SourcePathConfigurationProperty = "sourcePath";
        private const string DestinationConfigurationProperty = "destinationPath";

        public FileElement()
        {
        }

        [ConfigurationProperty(NameConfigurationProperty, DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string) this[NameConfigurationProperty]; }
            set { this[NameConfigurationProperty] = value; }
        }

        [ConfigurationProperty(SourcePathConfigurationProperty, DefaultValue = "", IsRequired = true)]
        public string SourcePath
        {
            get { return (string) this[SourcePathConfigurationProperty]; }
            set { this[SourcePathConfigurationProperty] = value; }
        }

        [ConfigurationProperty(DestinationConfigurationProperty, DefaultValue = "", IsRequired = true)]
        public string DestinationPath
        {
            get { return (string)this[DestinationConfigurationProperty]; }
            set { this[DestinationConfigurationProperty] = value; }
        }
    }
}
