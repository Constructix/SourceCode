using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Build.Evaluation;


namespace CreateCsProj
{
    class Program
    {
        static void Main(string[] args)
        {

            Project testProject = new Project();
            //testProject.SetProperty("DefaultTargets", "Build");
            testProject.SetProperty("TargetFrameworkVersion", "4.7.2");
            testProject.SetProperty("OutputType", "Exe");


            var itemGroup = testProject.Xml.CreateItemGroupElement();
            testProject.Xml.InsertAfterChild(itemGroup, testProject.Xml.LastChild);
            itemGroup.AddItem("Reference", "System");
            itemGroup.AddItem("Reference", "System.Xml");
            itemGroup.AddItem("Reference", "System.Collections.Generic");

            itemGroup = testProject.Xml.CreateItemGroupElement();
            testProject.Xml.InsertAfterChild(itemGroup, testProject.Xml.LastChild);
            itemGroup.AddItem("Compile", @"D:\Temp\Person.cs");

            itemGroup = testProject.Xml.CreateItemGroupElement();
            testProject.Xml.InsertAfterChild(itemGroup, testProject.Xml.LastChild);
            itemGroup.AddItem("Folder", @"References");
            

            testProject.Save(@"D:\Temp\useApiDemo.csproj");



            //MemoryStream ms = new MemoryStream();
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Encoding = Encoding.UTF8;
            //settings.Indent = true;
            //XmlTextWriter xmlTxtWriter = new XmlTextWriter(ms, null);

            //xmlTxtWriter.WriteStartDocument();
            //#region Project Element
            //xmlTxtWriter.WriteStartElement("Project");
            //xmlTxtWriter.WriteAttributeString("ToolsVersion", "15.0");
            //xmlTxtWriter.WriteAttributeString("DefaultTargets", "Build");
            //xmlTxtWriter.WriteAttributeString("xmlns", "http://schemas.microsoft.com/developer/msbuild/2003");
            //#endregion

            //// property Group
            //xmlTxtWriter.WriteStartElement("PropertyGroup");
            //xmlTxtWriter.WriteElementString("OutputType", "Exe");
            //xmlTxtWriter.WriteElementString("RootNamespace", "ATONITR201902");
            //xmlTxtWriter.WriteElementString("AssemblyName","CreateProjectWriter");

            //xmlTxtWriter.WriteEndElement();


            //xmlTxtWriter.WriteStartElement("ItemGroup");
            //xmlTxtWriter.WriteStartElement("Reference");
            //xmlTxtWriter.WriteAttributeString("Include", "System");
            //xmlTxtWriter.WriteEndElement();
            //xmlTxtWriter.WriteStartElement("Reference");
            //xmlTxtWriter.WriteAttributeString("Include", "System.Xml");
            //xmlTxtWriter.WriteEndElement();
            //xmlTxtWriter.WriteStartElement("Reference");
            //xmlTxtWriter.WriteAttributeString("Include", "System.Collections.Generic");
            //xmlTxtWriter.WriteEndElement();

            //xmlTxtWriter.WriteEndElement();

            //// files
            //xmlTxtWriter.WriteStartElement("ItemGroup");
            //xmlTxtWriter.WriteStartElement("Compile");
            //xmlTxtWriter.WriteAttributeString("Include", @"D:\Temp\person.cs");
            //xmlTxtWriter.WriteEndElement();
            //xmlTxtWriter.WriteEndElement();


            //xmlTxtWriter.WriteEndElement();
            //xmlTxtWriter.WriteEndDocument();

            //xmlTxtWriter.Flush();
            //ms.Position = 0;

            //byte[] contentsAsBytes = new byte[(int) ms.Length];

            //int bytesWritten = ms.Read(contentsAsBytes, 0, contentsAsBytes.Length);
            //Console.WriteLine(bytesWritten == contentsAsBytes.Length);
            //Console.WriteLine(ASCIIEncoding.ASCII.GetString(contentsAsBytes));


            //File.WriteAllText(@"D:\Temp\Firstproject.csproj", ASCIIEncoding.ASCII.GetString(contentsAsBytes));
        }
    }

    public class ProjectWriter
    {

    }
}
