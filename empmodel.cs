using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class empmodel
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> RankID { get; set; }
        public Nullable<decimal> Bonus { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string Rank { get; set; }
        public string DepartmentName { get; set; }
    }
}