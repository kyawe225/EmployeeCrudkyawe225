using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DBA.Tables;

namespace Employee.DBA.Context
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<EmployeeTable> employees { set; get; }
        public DbSet<Department> departments { set; get; }
        public DbSet<Position> positions { set; get; }
        public DbSet<DepartmentPosition> department_positions { set; get; }
        public DbSet<EmployeeDepartmentPosition> employee_department_positions { set; get; }

    }
}
