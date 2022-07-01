using FluentNHibernate.Mapping;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public abstract class BaseMapConAuditoria<T> : BaseEntityMap<T> where T : BaseEntityConAuditoria
    {
        public BaseMapConAuditoria()
            : base()
        {
            Map(x => x.UsuarioCreacion);
            Map(x => x.FechaCreacion);
            Map(x => x.UsuarioModificacion).Nullable();
            Map(x => x.FechaModificacion).Nullable();
            Map(x => x.UsuarioEliminacion).Nullable();
            Map(x => x.FechaEliminacion).Nullable();
        }
    }
}
