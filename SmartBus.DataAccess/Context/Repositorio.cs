using NHibernate;
using SmartBus.Entities;
using SmartBus.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Context
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad>
    {
        private readonly ISession session;

        public Repositorio(ISession _session)
        {
            session = _session;
        }
        public TEntidad Get(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidad> Query()
        {
            throw new NotImplementedException();
            return session.Query<TEntidad>();
        }

        public void Remove(TEntidad entity)
        {
            throw new NotImplementedException();
        }
    }
}
