using System.Linq;
using Employee.DBA.Context;
using Employee.DBA.Repositiory.Interfaces;
using Employee.DBA.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee.DBA;

namespace Employee.DBA.Repositiory.Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext context;
        public EmployeeRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<EmployeeTable> All()
        {
            return context.employees.AsNoTracking().OrderByDescending(p => p.UpdatedAt).AsEnumerable();
        }

        public bool Create(EmployeeTable entity)
        {
            context.employees.Add(entity);
            return true;
        }

        public bool Delete(EmployeeTable entity)
        {
            context.employees.Remove(entity);
            return true;
        }

        public EmployeeTable GetById(Guid guid)
        {
            return context.employees.Where(p=> p.Id.Equals(guid)).First();
        }

        public IEnumerable<EmployeeDto> search(Guid? DepartmentId = null, Guid? PositionId = null, string? Name = null, Guid? EmployeeId = null)
        {
            var query = context.employees.Join(context.employee_department_positions, p => p.Id, q => q.EmployeeId, (p, q) => new { p, q }
            ).Join(context.department_positions.Include(p => p.department).Include(p => p.position), o => o.q.DepartmentPositonId, t => t.Id, (o, t) => new
            {
                o,t
            });

            if (DepartmentId != null)
            {
                query=query.Where(obj=> obj.t.DepartmentId==DepartmentId);
            }
            if(PositionId != null)
            {
                query=query.Where(obj => obj.t.PositionId == PositionId);
            }
            if(Name != null)
            {
                query=query.Where(obj => obj.o.p.FirstName == Name);
            }
            if(EmployeeId != null)
            {
               query= query.Where(obj => obj.o.p.Id.Equals(EmployeeId));
            }
            var objects = query.AsNoTrackingWithIdentityResolution().AsEnumerable().GroupBy(p => p.o.p).Select(p => new EmployeeDto
            {
                Id = p.Key.Id,
                FirstName = p.Key.FirstName,
                LastName = p.Key.LastName,
                FatherName = p.Key.FatherName,
                Address = p.Key.FatherName,
                DOB = p.Key.DOB,
                Email = p.Key.Email,
                DepartmentNames = String.Join(',', p.Select(q => q.t.department.Name)),
                PositionNames = String.Join(',', p.Select(q => q.t.position.Name))
            }).ToList();
            //var objects = query.AsNoTrackingWithIdentityResolution().AsEnumerable().ToList();
            return objects;
        }

        public bool Update(EmployeeTable entity)
        {
            context.employees.Update(entity);
            return true;
        }
    }
}
