using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class FileRetrieverSection : ConfigurationSection
    {
        [ConfigurationProperty("files")]
        public FileElementCollection Files
        {
            get { return (FileElementCollection) this["files"]; }
        }
    }


    [ConfigurationCollection(typeof (FileElement))]
    public class FileElementCollection : ConfigurationElementCollection
    {


        public FileElement this[int index]
        {
            get { return (FileElement) BaseGet(index); }
            set
            {
                if(BaseGet(index )!= null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement) element).Name;
        }
    }


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
