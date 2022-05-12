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
            //role.DisplayDataBasedOnDate();
            repo.GetAllEmployees();
            Console.WriteLine("\nSalary details");
            repo.GetAllEmployeeSalary();
            // repo.UpdateEmployee(role);
            while (true)
            {
                Console.WriteLine("1)SumofsalarybyGender\n" + "2)Maxof salary by genger\n"
                                   + "4)Min of slary by gender\n" + "5)CountPersonByGender\n");

                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            repo.SumOfSalaryGenderWise();
                            break;
                        case 2:
                            repo.MaxSalaryGenderWise();
                            break;
                        case 3:
                            repo.MinSalaryGenderWise();
                            break;
                        case 4:
                            repo.CountEmployeeGenderWise();
                            break;
                        default:
                            Console.WriteLine("Please Enter correct option");
                            break;
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("Do you want to continue(Y / N) ? ");
                    var variable = Console.ReadLine();
                    if (variable.Equals("y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }

            }
            Console.ReadKey();
        }

    }
}
