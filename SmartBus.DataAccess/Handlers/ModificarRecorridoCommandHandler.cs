using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarRecorridoCommandHandler : CommandHandler<ModificarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        public ModificarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Recorrido> ResolverCommand(ModificarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var recorrido = session.Get<Recorrido>(command.Id);

            recorrido.Nombre = command.Nombre;
            recorrido.EsRecorridoDeIda = command.EsRecorridoDeIda;
            recorrido.Horario = command.Horario;
            recorrido.Escuela = session.Get<Escuela>(command.IdEscuela);
            recorrido.AñoCreacion = DateTime.Now.Year;
            recorrido.UsuarioModificacion = userContext.NombreUsuario;
            recorrido.FechaModificacion = DateTime.Now;
            recorrido.Pasajeros = SetearPasajeros(command.IdPasajeros);

            return Task.FromResult(recorrido);
        }

        private List<Pasajero> SetearPasajeros(IEnumerable<int> idPasajeros)
        {
            return session.Query<Pasajero>()
                .Where(p => idPasajeros.Contains(p.Id) && !p.Eliminado)
                .ToList();
        }
    }
}
