using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace EmployeePayrol_DB
{
    public class EmployeeRepo
    {
        public static string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = EmployeePayroll; Integrated Security = True";
        SqlConnection Connection = new SqlConnection(connectionstring);

        /// <summary>
        /// UC 1 Checks the database connection.
        /// </summary>
        public bool CheckDBConnection()
        {
            try
            {
                this.Connection.Open();
                Console.WriteLine("Connection Success");
                this.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
