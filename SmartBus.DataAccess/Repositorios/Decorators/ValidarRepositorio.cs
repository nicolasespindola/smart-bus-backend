using SmartBus.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Repositorios.Decorators
{
    public class ValidarRepositorio<T> : IRepositorio<T>
    {
        private readonly IRepositorio<T> repositorio;

        public ValidarRepositorio(IRepositorio<T> _repositorio)
        {
            repositorio = _repositorio;
        }

        public T Get(long id)
        {
            return repositorio.Get(id);
        }

        public IQueryable<T> Query()
        {
            return repositorio.Query();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
