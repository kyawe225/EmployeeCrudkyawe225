using Employee.DBA.Repositiory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DBA.Context;
using Employee.DBA.Repositiory.Classes;
using Microsoft.EntityFrameworkCore.Storage;

namespace Employee.DBA.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepository _employeesrepo;
        public IEmployeeRepository employeesrepo { set { _employeesrepo = value; } get { return (_employeesrepo == null) ? new EmployeeRepository(_context) : _employeesrepo; } }
        private IDepartmentRepository _departmentsrepo;

        public IDepartmentRepository departmentsrepo { set { _departmentsrepo = value; } get { return (_departmentsrepo == null) ? new DepartmentRepository(_context) : _departmentsrepo; } }
        private IPositionRepository _positionssrepo;
        public IPositionRepository positionsrepo { set { _positionssrepo = value; } get { return (_positionssrepo == null) ? new PositionRepository(_context) : _positionssrepo; } }
        private IDepartmentPositionRepository _departmentPositionsrepo;
        public IDepartmentPositionRepository departmentPositionsrepo { set { _departmentPositionsrepo = value; } get { return (_departmentPositionsrepo == null) ? new DepartmentPositionRepository(_context) : _departmentPositionsrepo; } }
        private IEmployeeDepartmentPositionRepository _employeeDepartmentPositionsrepo;

        public IEmployeeDepartmentPositionRepository employeeDepartmentPositionsrepo { set { _employeeDepartmentPositionsrepo = value; } get { return (_employeeDepartmentPositionsrepo == null) ? new EmployeeDepartmentPositionRepository(_context) : _employeeDepartmentPositionsrepo; } }
        private IDbContextTransaction dbContextTransaction { set; get; }
        private ApplicationContext _context { init; get; }
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            dbContextTransaction=this._context.Database.BeginTransaction();
        }

        public void Commit()
        {
            dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            dbContextTransaction.Rollback();
        }
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
