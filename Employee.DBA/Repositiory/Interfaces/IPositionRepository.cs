using Employee.DBA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBA.Repositiory.Interfaces
{
    public interface IPositionRepository: ICreateRepositiory<Position>, IUpdateRepository<Position>, IDeleteRepository<Position>, ISelectRepository<Position>
    {
    }
}
