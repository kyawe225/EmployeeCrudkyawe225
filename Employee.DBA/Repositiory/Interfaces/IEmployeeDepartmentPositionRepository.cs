using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DBA.Tables;

namespace Employee.DBA.Repositiory.Interfaces
{
    public interface IEmployeeDepartmentPositionRepository:ISelectRepository<EmployeeDepartmentPosition>
    {
        void CreateRange(IList<EmployeeDepartmentPosition> emp);
        void DeleteEmployeeRelatedPositions(EmployeeTable emp);
    }
}
