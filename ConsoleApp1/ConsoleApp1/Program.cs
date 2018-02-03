using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Customers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //connection.InfoMessage += Connection_InfoMessage;
            //connection.StateChange += Connection_StateChange;

            //connection.Open();
            // bulkUpdate
            Type customerType = typeof(Customer);


            Console.WriteLine(customerType.Name);
            foreach (PropertyInfo currentPropertyInfo in customerType.GetProperties())
            {
                    Console.WriteLine(currentPropertyInfo.Name + "  "+ currentPropertyInfo.PropertyType.Name);
            }



        }

        private static void BulkInsert()
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < 1000; i++)
            {
                Customer newCustomer = new Customer
                {
                    FirstName = "Richard",
                    LastName = "Jones",
                    EmailAddress = "r_jones@constructix.com.au"
                };
                customers.Add(newCustomer);
            }
            var bulkCopy =
                new SqlBulkCopy(
                    @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Customers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            bulkCopy.DestinationTableName = "Customer";

            DataTable customerTable = new DataTable("Customer");


            DataColumn idColumn = new DataColumn();
            idColumn.ColumnName = "Id";
            idColumn.DataType = Type.GetType("System.Int32");
            idColumn.AutoIncrement = true;
            customerTable.Columns.Add(idColumn);


            customerTable.Columns.Add("FirstName", typeof(string));
            customerTable.Columns.Add("LastName", typeof(string));
            customerTable.Columns.Add("EmailAddress", typeof(string));


            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                DataRow row = customerTable.NewRow();

                row["FirstName"] = "Richard";
                row["LastName"] = "Jones";
                row["EmailAddress"] = "r_jones@constructix.com.au";

                customerTable.Rows.Add(row);
            }
            watch.Stop();

            
            bulkCopy.WriteToServer(customerTable);
            Console.WriteLine($"Total Time taken: {watch.Elapsed.TotalMilliseconds}");
        }

        private static void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
           
        }

        private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine("Connection Info Message Fired.");
        }
    }


    public class TestReader<T> : List<T>, IDataReader
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public int FieldCount { get; }

        object IDataRecord.this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        object IDataRecord.this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public int Depth { get; }
        public bool IsClosed { get; }
        public int RecordsAffected { get; }
    }




    
    public class Customer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
