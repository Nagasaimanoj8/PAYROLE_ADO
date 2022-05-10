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
                            role.Phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            role.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            role.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            role.TaxablePay = Convert.ToDouble(reader["TaxablePAy"] == DBNull.Value ? default : reader["Taxable"]);
                            role.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                            role.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            role.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", role.EmployeeId, role.Name, role.Gender, role.Address, role.BasicPay, role.Phone, role.Deduction, role.Department, role.startdate);
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
                    command.Parameters.AddWithValue("@phone", role.Phone);
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
    }
}
