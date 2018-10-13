using System.Collections.Generic;

namespace CleanSkinGenerator
{
    public class Columns
    {
        private Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        public int this[string columnName]
        {
            get
            {
                Column col;
                if(_columns.TryGetValue(columnName, out col ))
                    return _columns[columnName].Index;
                else
                    return -1;
               
            }
        }

        public void Add(Column newColumn)
        {
            if(!_columns.ContainsKey(newColumn.Name))

                _columns.Add(newColumn.Name, newColumn);
        }

       
    }
}