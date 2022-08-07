using Employee.DBA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Repositiory.Interfaces
{
    public interface IEmployeeRepository : ICreateRepositiory<EmployeeTable>,IUpdateRepository<EmployeeTable>,IDeleteRepository<EmployeeTable>,ISelectRepository<EmployeeTable>
    {
        public IEnumerable<EmployeeDto> search(Guid? DepartmentId=null,Guid? PositionId=null,string? Name=null,Guid? EmployeeId = null); 
    }
}
