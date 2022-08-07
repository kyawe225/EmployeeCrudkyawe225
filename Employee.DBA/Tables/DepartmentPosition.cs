using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Tables
{
    public class DepartmentPosition : BaseTable
    {
        [ForeignKey("department")]
        public Guid DepartmentId { set; get; }
        public virtual Department? department { set; get; }
        [ForeignKey("position")]
        public Guid PositionId { set; get; }
        public virtual Position? position { set; get; }
    }
}
