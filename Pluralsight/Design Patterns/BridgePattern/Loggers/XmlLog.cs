using System;
using System.IO;
using System.Xml.Linq;

namespace BridgePattern
{
    public class XmlLog : ILog
    {
        public XmlLog(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; set; }
        public void LogMessage(string messageToLog)
        {


            DateTime currentDateTime = DateTime.Now;
            DateTimeOffset off = currentDateTime;

            string offset = (off.Offset.Hours > 0 ? string.Concat("+", off.Offset.Hours): string.Concat("-", off.Offset.Hours));
            

            string formattedCurrentDateTime = string.Concat(currentDateTime.ToString("yyyy-MM-dd'T'HH:mm:ssZ"), offset);

            XDocument doc=  new XDocument();
            XElement logsXElement;
            if (!File.Exists(FileName))
            {
                logsXElement = new XElement("logs");
            }
            else
            {
                doc = XDocument.Load(FileName);
                logsXElement = doc.Root;
            }

            XElement logElement = new XElement("Log", 
                                new XElement("Message", messageToLog, new XAttribute("dateTime", formattedCurrentDateTime)));


            logsXElement.Add(logElement);


            logsXElement.Save(FileName);
        }
    }
}