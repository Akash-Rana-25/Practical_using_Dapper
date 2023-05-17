using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDB_Dapper
{
    internal class Employee
    {
        public int Employee_PK { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int EmpCode { get; set; }
        public int Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public Nullable<decimal> salary { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public Nullable<System.DateTime> ResignDate { get; set; }
    }
}
