using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Tables
{
    public class Position:BaseTable
    {
        [StringLength(255)]
        public string Name { set; get; }
    }
}
