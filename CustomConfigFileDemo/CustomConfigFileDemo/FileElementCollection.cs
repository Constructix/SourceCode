using System.Configuration;

namespace CustomConfigFileDemo
{
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
}