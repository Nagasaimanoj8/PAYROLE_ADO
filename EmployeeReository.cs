using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    public class EmployeeReository
    {
        public static string ConnectionString = @"Data Source = DESKTOP-RKMTS0O; Initial Catalog = PayRoll; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = null;// VariableCreated
        //Fetching All The DataFromDataBase Using Getallemployees
        public void GetAllEmployees()
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))//Creating Object And initializing to the variable
                {
                    //SqlCommand sqlCommand=new sqlCommand();
                    EmployeePayRole role = new EmployeePayRole();
                    string query = "select * from employeee_payroll";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            role.EmployeeId = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                            //role.EmployeeId=Convert.ToInt(reader[0]);
                            role.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            role.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            role.startdate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                            role.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            //role.Phonem=number =Convert.ToDouble(reader["phone"]);
                            role.phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["phone"]);
                            role.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            role.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            role.TaxablePay = Convert.ToDouble(reader["TaxablePAy"] == DBNull.Value ? default : reader["Taxable"]);
                            role.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                            role.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            role.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", role.EmployeeId, role.Name, role.Gender, role.Address, role.BasicPay, role.phone, role.Deduction, role.Department, role.startdate);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows Present");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void GetAllEmployeeSalary()
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))//Creating Object And initializing to the variable
                {
                    //SqlCommand sqlCommand=new sqlCommand();
                    Salary role = new Salary();
                    string query = "select * from Salary";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            role.Salaryid = Convert.ToInt32(reader["Salaryid"] == DBNull.Value ? default : reader["Salaryid"]);
                            //role.EmployeeId=Convert.ToInt(reader[0]);
                            role.Employeeid = Convert.ToInt32(reader["Employeeid"] == DBNull.Value ? default : reader["Employeeid"]);
                            role.SalaryDetails = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                            Console.WriteLine("{0},{1},{2}", role.Employeeid, role.SalaryDetails, role.Salaryid);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows Present");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //AddEmployee
        public void AddEmployee(EmployeePayRole role)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeePayRole displayModel = new EmployeePayRole();
                    SqlCommand command = new SqlCommand("dbo.spAddEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", role.Name);
                    command.Parameters.AddWithValue("@Address", role.Address);
                    command.Parameters.AddWithValue("@BasicPay", role.BasicPay);
                    command.Parameters.AddWithValue("@phone", role.phone);
                    command.Parameters.AddWithValue("@Gender", role.Gender);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        Console.WriteLine("Employee inserted sucessfully into table ");
                    else
                        Console.WriteLine("Not inserted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void UpdateEmployee(EmployeePayRole role)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeePayRole displayModel = new EmployeePayRole();
                    SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", role.Name);
                    command.Parameters.AddWithValue("@Id", role.EmployeeId);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        Console.WriteLine("Updated sucessfull ");
                    else
                        Console.WriteLine("Updated Unsucessfull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void DeleteEmployee(EmployeePayRole role)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeePayRole displayModel = new EmployeePayRole();
                    SqlCommand command = new SqlCommand("dbo.spDeleteEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", role.EmployeeId);
                    command.Parameters.AddWithValue("@phone", role.phone);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        Console.WriteLine("Updated sucessfull ");
                    else
                        Console.WriteLine("Updated Unsucessfull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void  DisplayDataBasedOnDate(DateTime startdate, DateTime dateTime)
        {
            EmployeePayRole role = new EmployeePayRole();
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("RetrieveDate", connection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    //adding the parameter to the strored procedure
                    sqlCommand.Parameters.AddWithValue("@startDate", startdate);
                    sqlCommand.Parameters.AddWithValue("@endDate", dateTime);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //if it has data
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //store each data in the employee details properties 
                            role.EmployeeId = Convert.ToInt32(reader["id"]);
                            role.Name = reader["name"].ToString();
                            role.Gender = reader["gender"].ToString();
                            role.startdate = reader.GetDateTime(2);
                            role.phone = Convert.ToInt32(reader["phoneNumber"]);
                            role.Address = reader.GetString(5);
                            role.Department = reader.GetString(6);
                            //display the result
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", role.EmployeeId, role.Name, role.Gender, role.startdate, role.phone, role.Address, role.Department);
                            ;
                        }
                        reader.Close();
                        return;
                    }
                    else
                    {
                        reader.Close();
                    }
                }
            }
            //if any exception occurs catch and display exception message
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //finally close the connection
            finally
            {
                connection.Close();
            }
        }

        public void SumOfSalaryGenderWise()
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT gender,sum(basic_pay) as CombineSalary from employeee_payroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("SumOfSalaryGenderWise");
                            Console.Write(dataReader.GetString(0) + "\t" + dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                        connection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void MaxSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeePayRole role = new EmployeePayRole();
                    string query = @"select Gender,Max(BasicPay) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + "\t");
                            Console.WriteLine(reader.GetDouble(1));
                        }
                        reader.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void MinSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                   EmployeePayRole role = new EmployeePayRole();
                    string query = @"select Gender,Min(BasicPay) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + "\t");
                            Console.WriteLine(reader.GetDouble(1));
                        }
                        reader.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void CountEmployeeGenderWise()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeePayRole role= new EmployeePayRole();
                    string query = @"select Gender,Count(Gender) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + "\t");
                            Console.WriteLine(reader.GetInt32(1));
                        }
                        reader.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}

