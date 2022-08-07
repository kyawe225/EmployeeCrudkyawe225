using Employee.DBA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Repositiory.Interfaces
{
    public interface ICreateRepositiory<T> where T : BaseTable
    {
        bool Create(T entity);
    }
    public interface IUpdateRepository<T> where T : BaseTable
    {
        bool Update(T entity);
    }
    public interface ISelectRepository<T> where T : BaseTable
    {
        IEnumerable<T> All();
        T? GetById(Guid guid);
    }
    public interface IDeleteRepository<T> where T : BaseTable
    {
        bool Delete(T entity);
    }
}
