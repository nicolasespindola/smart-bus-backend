using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using SmartBus.Entities.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarPasajeroCommandHandler : CommandHandler<AgregarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        private readonly IPasajeroFactory pasajeroFactory;
        public AgregarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext, IPasajeroFactory _pasajeroFactory)
            : base(_session)
        {
            userContext = _userContext;
            pasajeroFactory = _pasajeroFactory;
        }

        public override Task<Pasajero> ResolverCommand(AgregarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var nuevoPasajero = pasajeroFactory.Crear(command.Nombre, 
                                                      command.Apellido, 
                                                      command.FechaNacimiento, 
                                                      command.Telefono, 
                                                      command.Domicilio, 
                                                      command.PisoDepartamento, 
                                                      command.EmailTutores,
                                                      userContext.NombreUsuario);

            return Task.FromResult(nuevoPasajero);
        }
    }
}
