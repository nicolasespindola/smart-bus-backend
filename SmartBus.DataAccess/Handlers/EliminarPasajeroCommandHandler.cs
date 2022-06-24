using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarPasajeroCommandHandler : CommandHandler<EliminarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        public EliminarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Pasajero> ResolverCommand(EliminarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var pasajero = session.Get<Pasajero>(command.Id);

            pasajero.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(pasajero);
        }

        public override void PostResolverCommand(Pasajero respuesta)
        {
            var RecorridosAsociados = session.Query<Recorrido>()
                .Where(r => !r.Eliminado 
                    && r.Pasajeros.Any(p => p.Id == respuesta.Id));

            foreach(var recorrido in RecorridosAsociados)
            {
                recorrido.Pasajeros = recorrido.Pasajeros.Where(p => p.Id != respuesta.Id);
                recorrido.UsuarioModificacion = userContext.NombreUsuario;
                recorrido.FechaModificacion = DateTime.Now;

                session.SaveOrUpdate(recorrido);
            }
        }
    }
}
