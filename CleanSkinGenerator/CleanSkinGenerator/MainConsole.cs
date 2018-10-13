using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace CleanSkinGenerator
{
    public static class MainConsole
    {
        
        public static void Main(string [] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("Invalid input file.");
                return;
            }

            // Steps to generate clean skin.
            // 1. Open Excel file.
            // 2. Extract data
            // 3. Store in object structure
            // 4. Write to xmlString.

            // object structure
            //  a. Overall have a Manager class to corordinate
            //

            using (ExcelPackage package = new ExcelPackage(new FileInfo(args[0])))
            {
                Console.WriteLine("Excel file is opened.");


                ExcelFileChecker.WorkSheetExists(package, "Message Structure Table");

                MessageStructureExtractor extractor =
                    new MessageStructureExtractor(package.Workbook.Worksheets["Message Structure Table"]);
                var messageStructureData = extractor.Extract();



                PrintHeaders(messageStructureData);

                Console.WriteLine();
            }
        }
        static int tabCount = 0;
        private static void PrintHeaders(MessageStructureData messageStructureData)
        {
            Console.WriteLine("Headers and Tuples");
            Console.WriteLine(new string('-', 80));
            foreach (Header header in messageStructureData.Headers)
            {
                foreach (var fact in header.Facts)
                {
                    Console.WriteLine(fact.Name);
                }


                foreach (Tuple currentTuple in header.Tuples)
                {
                    Console.WriteLine(currentTuple.Name);
                    foreach (var currentTupleFact in currentTuple.Facts)
                    {
                        Console.WriteLine($"\t{currentTupleFact.Name}");
                    }
                    PrintList(currentTuple.LinkeListTuple);
                }
            }
        }

        
       
        private static void PrintList(LinkedList<Tuple> tuple)
        {
            foreach (Tuple currentTuple in tuple)
            {
                Console.WriteLine($"\t\t{currentTuple.Name}");
                
                    foreach (var innnerTupleFact in currentTuple.Facts)
                    {
                        Console.WriteLine($"\t\t\t{innnerTupleFact.Name}");
                    }
            }
        }
    }
    #region Columns

    #endregion

    public class Tuple
    {
        public int SequenceNumber { get; set; }
        public int ParentNumber {get; set; }
        public string Name { get; set; }

        public LinkedList<Tuple> LinkeListTuple { get; set; }
        public List<Fact> Facts { get; set; }

        public Tuple()
        {
            LinkeListTuple = new LinkedList<Tuple>();
            Facts = new List<Fact>();
        }
       

    }

    public interface IExtractor
    {
        string WorkSheetName { get; }
        ExcelWorksheet WorkSheet { get; }
    }

    public class MessageStructureExtractor : IExtractor
    {
        public string WorkSheetName { get; }
        public ExcelWorksheet WorkSheet { get; }
        private Columns _columns;

       
        public MessageStructureExtractor( ExcelWorksheet workSheet)
        {
            
            WorkSheet = workSheet;
        }

        private List<Header> headers = new List<Header>();

        public MessageStructureData Extract()
        {
            _columns = LoadColumns(WorkSheet);

            for (int rowIndex = 2; rowIndex < WorkSheet.Dimension.Rows; rowIndex++)
            {
                var seqNum = WorkSheet.Cells[rowIndex, _columns["SeqNum"]].GetValue<int>();
                var parentNum = WorkSheet.Cells[rowIndex, _columns["ParentSeqNum"]].GetValue<int>();
                var formElementType = WorkSheet.Cells[rowIndex, _columns["FormElementType"]].GetValue<string>();
                var reportLabel = WorkSheet.Cells[rowIndex, _columns["ReportLabel"]].GetValue<string>();
                var elementName = WorkSheet.Cells[rowIndex, _columns["TaxonomyReferenceElementName"]].GetValue<string>();
                var contextInstance = WorkSheet.Cells[rowIndex, _columns["ContextInstance"]].GetValue<string>();
                switch (formElementType)
                {
                        case "Heading":
                            AddHeading(headers, seqNum, reportLabel);
                            break;
                        case "Tuple":
                            AddTuple(headers, seqNum, parentNum, reportLabel, elementName, contextInstance);
                            break;
                        case "Fact":
                            AddFacts(headers, seqNum, parentNum, reportLabel, elementName, contextInstance);
                            break;
                }
            }
            return new MessageStructureData {Headers = headers};

        }

        private void AddFacts(List<Header> list, int seqNum, int parentNum, string reportLabel, string elementName, string contextInstance)
        {
            var heading = list.FirstOrDefault(x => x.SequenceNumber == parentNum);
            if (heading != null)
            {
                heading.Facts.Add(new Fact {Name = elementName, ParentNumber = parentNum, SequenceNumber = seqNum});
            }
            else
            {

                foreach (Header header in list)
                {

                    var lastTuple = header.Tuples.Last();
                    if (lastTuple != null)
                    {
                        if (lastTuple.SequenceNumber == parentNum)
                        {
                            lastTuple.Facts.Add( new Fact {Name = elementName, ParentNumber = parentNum, SequenceNumber = seqNum});
                        }
                        else
                        {
                            AddFactAsChild(lastTuple.LinkeListTuple,
                                new Fact {Name = elementName, ParentNumber = parentNum, SequenceNumber = seqNum});
                        
                        }
                    }

                   
                }
            }
        }

        private static void AddFactAsChild(LinkedList<Tuple> tuple, Fact newFact)
        {

            foreach (Tuple currentTuple in tuple)
            {

                if (currentTuple.SequenceNumber == newFact.ParentNumber)
                {
                    currentTuple.Facts.Add(newFact);
                    return;
                }
                AddFactAsChild(currentTuple.LinkeListTuple, newFact);
            }
        }



        private void AddTuple(List<Header> list, int seqNum, int parentNum, string reportLabel, string elementName,
            string contextInstance)
        {
            var header = list.Last();
            if (header?.SequenceNumber == parentNum)
            {
                header.Tuples.Add(new Tuple {Name = elementName,ParentNumber = parentNum,SequenceNumber = seqNum});
            }
            else
            {
                // search sub tuples if no exist then add onto 
                var parentTupleOfNewTuple = header.Tuples.First(x => x.SequenceNumber == parentNum);
                if (parentTupleOfNewTuple != null)
                {
                    parentTupleOfNewTuple.LinkeListTuple.AddLast(new Tuple {Name = elementName,ParentNumber = parentNum,SequenceNumber = seqNum});
                }
            }
        }


        private void AddHeading(List<Header> list, int seqNum, string reportLabel)
        {
            if (list.All(x => x.SequenceNumber != seqNum))
            {
               list.Add(new Header(seqNum, reportLabel));
            }
        }

        private static Columns LoadColumns(ExcelWorksheet worksheet)
        {
            var columns = new Columns();
            for (int colIndex = 1; colIndex < worksheet.Dimension.Columns; colIndex++)
            {

                var newColumn = new Column(colIndex, worksheet.Cells[1, colIndex].GetValue<string>());
                columns.Add(newColumn);
            }
            return columns;
    }
  
}

    public class Fact
    {
        public int SequenceNumber { get; set; }
        public int ParentNumber {get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Value { get; set; }

        public string ToXml()
        {
            StringBuilder builder = new StringBuilder();

            XmlWriter xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true});

            xmlWriter.WriteStartElement(Name);

            xmlWriter.WriteStartAttribute("Context");
            xmlWriter.WriteValue(Context);
            xmlWriter.WriteEndAttribute();

            xmlWriter.WriteValue(Value);

            xmlWriter.WriteEndElement();


            xmlWriter.Flush();

            return builder.ToString();
        }
    }


    internal class ContextStructureExtractor : IExtractor
    {
        public string WorkSheetName { get; }
        public ExcelWorksheet WorkSheet { get; }

        public ContextStructureExtractor(string workSheetName)
        {
            WorkSheetName = workSheetName;
        }
    }
}


