using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secmark.Models
{
    public class Department
    {
        public string dept_code {  get; set; }
        public string dep_name { get; set; }
    }
    public class Employee
    {
        public int emp_Srno { get; set; }
        public string emp_code { get; set; }
        public string emp_Name { get; set; }
        public string emp_Dept { get; set; }
    }

}
