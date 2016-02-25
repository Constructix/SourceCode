using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConfigFileDemo
{
    public class FileElement : ConfigurationElement
    {
        public FileElement()
        {
        }

        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("sourcePath", DefaultValue = "", IsRequired = true)]
        public string SourcePath
        {
            get { return (string) this["sourcePath"]; }
            set { this["sourcePath"] = value; }
        }

        [ConfigurationProperty("destinationPath", DefaultValue = "", IsRequired = true)]
        public string DestinationPath
        {
            get { return (string)this["destinationPath"]; }
            set { this["destinationPath"] = value; }
        }
    }
}
