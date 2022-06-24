using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarEventualidadCommandHandler : CommandHandler<AgregarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        public AgregarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Eventualidad> ResolverCommand(AgregarEventualidadCommand command, CancellationToken cancellationToken)
        {
            var nuevoEventualidad = new Eventualidad
            {
                IdRecorrido = command.IdRecorrido,
                IdPasajero = command.IdPasajero,
                FechaInicio = command.FechaInicio,
                FechaFin = command.FechaFin,
                Direccion = command.Direccion,
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = userContext.NombreUsuario
            };

            return Task.FromResult(nuevoEventualidad);
        }
    }
}
