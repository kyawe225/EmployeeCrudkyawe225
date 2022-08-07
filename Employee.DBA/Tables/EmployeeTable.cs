using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Employee.DBA.Tables
{
    public class EmployeeTable :BaseTable
    {
        [StringLength(125)]
        public string FirstName { set; get; }
        [StringLength(125)]
        public string LastName { set; get; }
        [StringLength(255)]
        public string FatherName { set; get; }
        [StringLength(155)]
        public string Email { set; get; }
        public DateTime DOB { set; get; }
        [StringLength(300)]
        public string Address { set; get; }
    }
}
