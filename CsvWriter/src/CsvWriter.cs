using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Constructix.Utilities
{
	public class CsvWriter
    {
        private Dictionary<string, string> propertyNames = new Dictionary<string, string>();



        public void Write(string fileName, object items)
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
            File.WriteAllText(fileName, builder.ToString());
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
    }

}
