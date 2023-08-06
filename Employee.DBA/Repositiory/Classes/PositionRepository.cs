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
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationContext _context;
        public PositionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Position> All()
        {
            return _context.positions.AsNoTracking().OrderByDescending(p=> p.UpdatedAt).AsEnumerable();
        }

        public IEnumerable<Position> All(bool all, string? departmentId = null)
        {
            if (!all)
            {
                return _context.department_positions.Where(p => p.DepartmentId == Guid.Parse(departmentId)).Select(p=> new Position
                {
                    Name=p.position.Name,
                    Id=p.PositionId
                }).AsEnumerable();
            }
            return null;
        }

        public bool Create(Position entity)
        {
            _context.positions.Add(entity);
            return true;
        }

        public bool Delete(Position entity)
        {
            _context.positions.Remove(entity);
            return true;
        }

        public Position GetById(Guid guid)
        {
            return _context.positions.Where(p=> p.Id.Equals(guid)).First();
        }

        public bool Update(Position entity)
        {
            _context.positions.Update(entity);
            return true;
        }
    }
}
