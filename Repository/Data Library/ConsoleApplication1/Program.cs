using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=ConstructixServices;Integrated Security=SSPI;");
            connection.StateChange += Connection_StateChange;
            connection.InfoMessage += Connection_InfoMessage;
            connection.Open();
            SqlCommand cmd = new SqlCommand("CREATE TABLE ProductCategory (ID int Identity)", connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine(e.CurrentState.ToString());
        }
    }
}
