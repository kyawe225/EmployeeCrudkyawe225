using Employee.DBA.Repositiory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository employeesrepo {  get; }
        public IDepartmentRepository departmentsrepo {  get; }
        public IPositionRepository positionsrepo {  get; }
        public IDepartmentPositionRepository departmentPositionsrepo {  get; }
        public IEmployeeDepartmentPositionRepository employeeDepartmentPositionsrepo {  get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
    }
}
