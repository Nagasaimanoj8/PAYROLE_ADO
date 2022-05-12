using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    class Program
    {
        public static void Main(string[] args)
        {
            EmployeePayRole role = new EmployeePayRole();
            role.Address = "Chicago";
            role.Name = "Sowmya";
            role.Gender = "Female";
            EmployeeReository repo = new EmployeeReository();
            Console.WriteLine("Employee Details between Start date and End date");
            repo.GetEmployeeDetailsByDate();
            repo.GetAllEmployees();
            Console.WriteLine("\nSalary details");
            repo.GetAllEmployeeSalary();
           // repo.UpdateEmployee(role);
            Console.ReadLine();
        }
    }
}
