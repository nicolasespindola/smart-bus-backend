using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public interface IEntityLoader
    {
        public T Load<T>(int id)
            where T : IBaseEntity;

        public IQueryable<T> Query<T>()
            where T : IBaseEntity;
        T Add<T>(T nuevoRecorrido)
            where T : IBaseEntity;
    }
}
