using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA
{
    public class EmployeeDto
    {
        public Guid Id { set; get; }
        
        public string FirstName { set; get; }
        
        public string LastName { set; get; }
        
        public string FatherName { set; get; }
        
        public string Email { set; get; }
        public DateTime DOB { set; get; }
        public string Address { set; get; }
        public string DepartmentNames { set; get; }
        public string PositionNames { set; get; }
    }
}
