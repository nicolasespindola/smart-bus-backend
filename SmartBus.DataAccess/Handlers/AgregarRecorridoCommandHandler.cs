
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
    public class AgregarRecorridoCommandHandler : CommandHandler<AgregarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        public AgregarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Recorrido> ResolverCommand(AgregarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var nuevoRecorrido = new Recorrido
            {
                Nombre = command.Nombre,
                EsRecorridoDeIda = command.EsRecorridoDeIda,
                Horario = command.Horario,
                Escuela = session.Get<Escuela>(command.IdEscuela),
                Chofer = session.Get<Chofer>(command.IdChofer),
                AñoCreacion = DateTime.Now.Year,
                UsuarioCreacion = userContext.NombreUsuario,
                FechaCreacion = DateTime.Now,
                Pasajeros = SetearPasajeros(command.IdPasajeros),
                Eliminado = false
            };

            return Task.FromResult(nuevoRecorrido);
        }

        private List<Pasajero> SetearPasajeros(IEnumerable<int> idPasajeros)
        {
            return session.Query<Pasajero>()
                .Where(p => idPasajeros.Contains(p.Id) && !p.Eliminado)
                .ToList();
        }
    }
}
