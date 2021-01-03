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
        /// <summary>
        ///UC 2 Gets all employee.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int GetAllEmployee()
        {
            try
            {
                int count = 0;
                EmployeeModel Model = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"Select * from EmployeePayroll;";
                    SqlCommand CMD = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader reader = CMD.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Model.Id = reader.GetInt32(0);
                            Model.name = reader.GetString(1);
                            Model.basic_pay = reader.GetDecimal(2);
                            Model.start_Date = reader.GetDateTime(3);
                            Model.gender = Convert.ToChar(reader.GetString(4));
                            Model.phoneNumber = reader.GetString(5);
                            Model.department = reader.GetString(6);
                            Model.address = reader.GetString(7);
                            Model.deduction = reader.GetDouble(8);
                            Model.taxable = reader.GetSqlSingle(9);
                            Model.netpay = reader.GetSqlSingle(10);
                            Model.income_tax = reader.GetDouble(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", Model.Id, Model.name, Model.basic_pay, Model.start_Date, Model.gender, Model.phoneNumber, Model.department, Model.address, Model.deduction, Model.taxable, Model.netpay, Model.income_tax);
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.Connection.Close();
                }
                return count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public decimal UpdateSalary(EmployeeModel updateModel)
        {
            try
            {
                using (this.Connection)
                {
                    SqlCommand updateCmd = new SqlCommand("SpUpdateSalary", this.Connection);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.Parameters.AddWithValue("@name", updateModel.name);
                    updateCmd.Parameters.AddWithValue("@basic_pay", updateModel.basic_pay);
                    this.Connection.Open();
                    updateCmd.ExecuteNonQuery();
                    Console.WriteLine("Salary Updated Succes");
                    this.Connection.Close();
                    //Console.WriteLine("{0},{1},{2},{3},{4},{5}", updateModel.Id, updateModel.name, updateModel.jobDiscription, updateModel.start_date, updateModel.salary, updateModel.salaryID);
                }
                return updateModel.basic_pay;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC 4 Retrives the particualr record.
        /// </summary>
        public int RetriveParticualrRecord()
        {
            int result = 0;
            try
            {
                EmployeeModel getParticularData = new EmployeeModel();
                using (this.Connection)
                {
                    string retriveQuery = @"select Count(Id) from EmployeePayroll where start_Date between CAST('2005-01-05' as date) AND GETDATE();";
                    SqlCommand CMD = new SqlCommand(retriveQuery, this.Connection);
                    this.Connection.Open();
                    result = (int)CMD.ExecuteScalar();
                    SqlDataReader reader = CMD.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            getParticularData.Id = reader.GetInt32(0);
                            Console.WriteLine("{0}", getParticularData.Id);
                        }
                    }
                    reader.Close();
                    this.Connection.Close();
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getAggrigateSumSalary()
        {
            try
            {
                int sum = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"select sum(basic_pay) from  EmployeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            sum = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.Connection.Close();
                    return sum;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getAvragSalary()
        {
            try
            {
                int avg = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"select avg(basic_pay) from  EmployeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            avg = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.Connection.Close();
                    return avg;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMinSalary()
        {
            try
            {
                int min = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"select min(basic_pay) from  EmployeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            min = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.Connection.Close();
                    return min;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMaxSalary()
        {
            try
            {
                int max = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"select max(basic_pay) from  EmployeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            max = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.Connection.Close();
                    return max;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the maximum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getCountSalary()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.Connection)
                {
                    string query = @"select count(basic_pay) from  EmployeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.Connection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC 6 Insert Record.
        /// </summary>
        /// <exception cref="Exception"></exception>

        public bool AddRecord(EmployeeModel Model)
        {
            try
            {
                using (this.Connection)
                {
                    SqlCommand CMD = new SqlCommand("SpAddEmployeePayroll", this.Connection);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@Id", Model.Id);
                    CMD.Parameters.AddWithValue("@name", Model.name);
                    CMD.Parameters.AddWithValue("@basic_pay", Model.basic_pay);
                    CMD.Parameters.AddWithValue("@start_Date", Model.start_Date);
                    CMD.Parameters.AddWithValue("@gender", Model.gender);
                    CMD.Parameters.AddWithValue("@phoneNumber", Model.phoneNumber);
                    CMD.Parameters.AddWithValue("@department", Model.department);
                    CMD.Parameters.AddWithValue("@address", Model.address);
                    CMD.Parameters.AddWithValue("@deduction", Model.deduction);
                    CMD.Parameters.AddWithValue("@taxable", Model.taxable);
                    CMD.Parameters.AddWithValue("@netpay", Model.netpay);
                    CMD.Parameters.AddWithValue("@income_tax", Model.income_tax);
                    this.Connection.Open();
                    var result = CMD.ExecuteNonQuery();
                    this.Connection.Close();

                    int employee_id = Model.Id;
                    SqlCommand sqlCommand = new SqlCommand("SpPayrollDeatil", this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", (Model.Id));
                    sqlCommand.Parameters.AddWithValue("@Deduction", (Model.deduction));
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", (Model.taxable));
                    sqlCommand.Parameters.AddWithValue("@NetPay", (Model.netpay));
                    sqlCommand.Parameters.AddWithValue("@Tax", (Model.income_tax));
                    this.Connection.Open();
                    var result1 = sqlCommand.ExecuteNonQuery();
                    this.Connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.Connection.Close();
            }
        }
    }
}
