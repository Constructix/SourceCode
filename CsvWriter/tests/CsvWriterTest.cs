using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using CsvWriter.Tests.DomainObjects;

namespace CsvWriter.Tests
{
    public class CsvWriterTest
    {
        private const string fileName = "persons.csv";

        [Fact]
        public void Test1()
        {

            List<Person> persons = new List<Person> 
            {
                new Person {FirstName = "Richard", LastName = "Jones"}, 
                new Person { LastName = "Gates", FirstName = "Bill"}
            };


            var writer = new Constructix.Utilities.CsvWriter();

            writer.Write(fileName, persons);

            File.Exists(fileName);

            var csvContents = File.ReadAllText(fileName);

            var splitData = csvContents.Split(",");

            Assert.True(splitData[0].Equals("FirstName"));
            Assert.True(splitData[1].Equals("LastName"));

        }

        [Fact]
        public void StreamWriterTest()
        {

            StreamWriter writer = new StreamWriter(@"writer.csv");
        }

        [Fact]
        public void CSVWriterWriteSharePricesToFile()
        {
            List<Stock> stocks = new List<Stock> { 
                                                    new Stock { Code = "AMP",
                                                                        DateTime = DateTime.Today.AddDays(-2),
                                                                        Ask = 3.00m,
                                                                        Offer = 3.01m,
                                                                        High = 3.22m,
                                                                        Low = 2.95m, Open = 3.15m, Close = 3.00m },
                                                    new Stock { Code = "GXY",
                                                                        DateTime = DateTime.Today,
                                                                        Ask = 2.00m,
                                                                        Offer = 2.01m,
                                                                        High = 2.22m,
                                                                        Low = 1.95m, Open = 2.15m, Close = 2.00m },
                                                    new Stock { Code = "GXY",
                                                                        DateTime = DateTime.Today.AddDays(1),
                                                                        Ask = 2.15m,
                                                                        Offer = 2.16m,
                                                                        High = 2.23m,
                                                                        Low = 1.90m, Open = 2.00m, Close = 2.15m }};
            var writer = new Constructix.Utilities.CsvWriter();
            var fileName = @"D:\Files\shares.csv";
            writer.Write(fileName, stocks);
        }

        [Fact]
        public void CSV2WriterTest()
        {


            List<Person> persons = new List<Person>
            {
                new Person {FirstName = "Richard", LastName = "Jones"},
                new Person { LastName = "Gates", FirstName = "Bill"},
                new Person { LastName = "Jones", FirstName = "Teresa"},
                new Person { LastName = "Jones", FirstName = "Douglas"},
            };


            using (FileStream fs = new FileStream(@"D:\Files\TestCSVWriter2.csv", FileMode.Create))
            {
                using (var csv2writer = new CSV2Writer(fs))
                {

                    csv2writer.Write(persons);
                    
                }
            }

            var buffer = new byte[100000];
            using (Stream s = new MemoryStream(buffer))
            {
                using (var csv2Writer = new CSV2Writer(s))
                {
                    csv2Writer.Write(persons);

                }
            }


            int counter = 0;
            while (buffer[counter] != 0)
            {
                counter++;
            }

            var arraySpan = new Span<byte>(buffer);
            File.WriteAllBytes(@"D:\Files\TestMemoryStreamUsingBytes.csv", arraySpan.Slice(0, counter).ToArray());
            
        }
    }

    public class CSV2Writer : StreamWriter
    {
        private Dictionary<string, string> propertyNames = new Dictionary<string, string>();


        public CSV2Writer(Stream stream) : base(stream)
        {
        }

        public CSV2Writer(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }

        public CSV2Writer(Stream stream, Encoding encoding, int bufferSize) : base(stream, encoding, bufferSize)
        {
        }

        public CSV2Writer(Stream stream, Encoding? encoding = null, int bufferSize = -1, bool leaveOpen = false) : base(stream, encoding, bufferSize, leaveOpen)
        {
        }

        public CSV2Writer(string path) : base(path)
        {
        }

        public CSV2Writer(string path, bool append) : base(path, append)
        {
        }

        public CSV2Writer(string path, bool append, Encoding encoding) : base(path, append, encoding)
        {
        }

        public CSV2Writer(string path, bool append, Encoding encoding, int bufferSize) : base(path, append, encoding, bufferSize)
        {
        }

        #region Methods

        public override void Write(object items)
        {
            Console.WriteLine(items.GetType().GetGenericTypeDefinition().Name);
            var builder = new StringBuilder();
            AssignPropertyNamesFromItems(items);
            BuildCSVHeader(builder);
            IList l = items as IList;
            var currentType = items.GetType().GenericTypeArguments.FirstOrDefault();
            foreach (var element in l)
            {
                foreach (var propertyKey in propertyNames.ToList())
                {
                    builder.Append($"{currentType.GetProperty(propertyKey.Key).GetValue(element).ToString()},");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.AppendLine();
            }
            builder.Remove(builder.Length - 2, 2);

            this.Write(builder.ToString());
        }

        private void BuildCSVHeader(StringBuilder builder)
        {

            foreach (var element in propertyNames.Keys.ToList())
            {
                builder.Append($"{element},");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.AppendLine();

        }

        private void AssignPropertyNamesFromItems(object items)
        {

            var genericOfType = items.GetType();
            var currentType = genericOfType.GenericTypeArguments.FirstOrDefault();
            foreach (var currentPropertyInfo in currentType.GetProperties())
            {
                propertyNames.TryAdd(currentPropertyInfo.Name, currentPropertyInfo.Name);
            }
        }

        #endregion

    }
}
