using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    public class EmployeePayRole
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int phone { get; set; }
        public double BasicPay { get; set; }
        public DateTime startdate { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string sales { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }



    }
}
