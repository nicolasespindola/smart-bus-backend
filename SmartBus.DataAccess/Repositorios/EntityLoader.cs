using NHibernate;
using SmartBus.Entities;
using SmartBus.Entities.Factories;
using System.Linq;

namespace SmartBus.DataAccess.Repositorios
{
    public class EntityLoader : IEntityLoader
    {
        private readonly ISession session;
        public EntityLoader(ISession _session)
        {
            session = _session;
        }

        public T Load<T>(int id)
            where T : IBaseEntity
        {
            return session.Get<T>(id);
        }

        public IQueryable<T> Query<T>() 
            where T : IBaseEntity
        {
            return session.Query<T>();
        }
    }
}
