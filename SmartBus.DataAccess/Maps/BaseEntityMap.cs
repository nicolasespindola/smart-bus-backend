using FluentNHibernate.Mapping;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            DefinirId();
            Map(x => x.Eliminado);
        }

        public virtual void DefinirId()
        {
            Id(x => x.Id);
        }
    }
}
