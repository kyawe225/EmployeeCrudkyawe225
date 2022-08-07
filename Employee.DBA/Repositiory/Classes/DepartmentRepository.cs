using Employee.DBA.Context;
using Employee.DBA.Repositiory.Interfaces;
using Employee.DBA.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Repositiory.Classes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> All()
        {
            return _context.departments.AsNoTracking().OrderByDescending(p => p.UpdatedAt).AsEnumerable<Department>();
        }

        public bool Create(Department entity)
        {
            _context.departments.Add(entity);
            return true;
        }

        public bool Delete(Department entity)
        {
            _context.departments.Remove(entity);
            return true;
        }

        public Department GetById(Guid guid)
        {
            return _context.departments.Where(p => p.Id.Equals(guid)).First();
        }

        public bool Update(Department entity)
        {
            _context.departments.Update(entity);
            return true;
        }
    }
}
