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
            EmployeePayRole role= new EmployeePayRole();
            role.Name = "Sowmya";
            role.Gender = "Female";
            role.Address = "IceLand";
            role.BasicPay = 7894561;
            role.Phone = 789458977;
            EmployeeReository repo = new EmployeeReository();
            repo.AddEmployee(role);
            repo.GetAllEmployees();
            Console.ReadLine();
        }
    }
}
