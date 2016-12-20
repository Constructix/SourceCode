using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace BridgeDesignPattern
{
    public class XmlLogProvider : BaseLogProvider
    {
        public string FileName { get; set; }
        public override void WriteLog(string message)
        {
            XDocument doc;
            XElement root;
            if (File.Exists(this.FileName))
            {
                doc = XDocument.Parse(File.ReadAllText(this.FileName));
                root = doc.Descendants().FirstOrDefault();

            }
            else
            {
                doc = new XDocument();
                root = new XElement("Log");
                doc.Add(root);
            }

            
            XElement log = new XElement("log", message);
            log.SetAttributeValue("messageDateTime", XmlConvert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"), XmlDateTimeSerializationMode.Local));
            root.Add(log);

            doc.Save(File.OpenWrite(this.FileName));
            Console.WriteLine(root.ToString());
        }
    }


    public abstract class BaseLogManager
    {
        protected BaseLogProvider _baseLogProvider;
        public abstract void LogMessage(string message);
    }


    public class LogManager : BaseLogManager
    {

        public LogManager()
        {
            
        }

        public LogManager(BaseLogProvider baseLogProvider)
        {
            _baseLogProvider = baseLogProvider;
        }
        
        public override void LogMessage(string message)
        {
            _baseLogProvider.WriteLog(message);
        }
    }
}