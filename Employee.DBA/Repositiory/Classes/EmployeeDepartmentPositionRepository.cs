using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DBA.Context;
using Employee.DBA.Repositiory.Interfaces;
using Employee.DBA.Tables;

namespace Employee.DBA.Repositiory.Classes
{
    public class EmployeeDepartmentPositionRepository : IEmployeeDepartmentPositionRepository
    {
        private ApplicationContext context;
        public EmployeeDepartmentPositionRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<EmployeeDepartmentPosition> All()
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IList<EmployeeDepartmentPosition> emp)
        {
            this.context.employee_department_positions.AddRange(emp);
        }

        public void DeleteEmployeeRelatedPositions(EmployeeTable emp)
        {
            IEnumerable<EmployeeDepartmentPosition> relations=this.context.employee_department_positions.Where(p => p.EmployeeId.Equals(emp)).AsEnumerable();
            this.context.employee_department_positions.RemoveRange(relations);
        }

        public EmployeeDepartmentPosition GetById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
