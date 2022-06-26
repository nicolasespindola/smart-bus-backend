using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Base
{
    public interface IRepositorio<TEntidad>
    {
        IQueryable<TEntidad> Query();

        TEntidad Get(Int64 id);

        void Remove(TEntidad entity);
    }
}
