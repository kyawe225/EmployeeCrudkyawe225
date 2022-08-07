using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Tables
{
    public class BaseTable
    {
        [Key]
        public Guid Id { set; get; } = Guid.NewGuid();
        public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
        public string CreatedEmp { set; get; }
        public string UpdatedEmp { set; get; }
    }
}
