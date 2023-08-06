using Employee.DBA.Context;
using Employee.DBA.Repositiory.Interfaces;
using Employee.DBA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee.DBA.Repositiory.Classes
{
    public class DepartmentPositionRepository : IDepartmentPositionRepository
    {
        private ApplicationContext context;
        public DepartmentPositionRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<DepartmentPosition> All()
        {
            return context.department_positions.AsNoTracking().Include(p=> p.position).Include(p=> p.department).OrderByDescending(p => p.UpdatedAt).AsEnumerable();
        }

        public bool Create(DepartmentPosition entity)
        {
            context.department_positions.Add(entity);
            return true;
        }

        public bool Delete(DepartmentPosition entity)
        {
            context.department_positions.Remove(entity);
            return true;
        }

        public DepartmentPosition? GetById(Guid guid)
        {
            return context.department_positions.Where(p=> p.Id.Equals(guid)).FirstOrDefault();
        }
        public DepartmentPosition? GetByDepartmentId(Guid positionId,Guid departmentId)
        {
            return context.department_positions.Where(p => p.DepartmentId == departmentId).Where(p => p.PositionId == positionId).FirstOrDefault();
        }
    }
}
