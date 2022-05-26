using FluentNHibernate.Mapping;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public abstract class BaseMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Id(x => x.Id);
            Map(x => x.UsuarioCreacion);
            Map(x => x.FechaCreacion);
            Map(x => x.UsuarioModificacion).Nullable();
            Map(x => x.FechaModificacion).Nullable();
            Map(x => x.UsuarioEliminacion).Nullable();
            Map(x => x.FechaEliminacion).Nullable();
            Map(x => x.Eliminado);
        }
    }
}
