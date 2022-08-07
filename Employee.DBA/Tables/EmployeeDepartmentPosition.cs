using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Tables
{
    public class EmployeeDepartmentPosition :BaseTable
    {
        [ForeignKey("employee")]
        public Guid EmployeeId { set; get; }
        public virtual EmployeeTable? employee { set; get; }
        public virtual DepartmentPosition? departmentPosition { set; get; }
        [ForeignKey("departmentPosition")]
        public Guid DepartmentPositonId { set; get; }
    }
}
