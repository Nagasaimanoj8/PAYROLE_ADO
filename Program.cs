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
            role.EmployeeId = 3;
            role.Name = "NM";
            EmployeeReository repo = new EmployeeReository();
            repo.AddEmployee(role);
            repo.GetAllEmployees();
           // repo.UpdateEmployee(role);
            Console.ReadLine();
        }
    }
}
