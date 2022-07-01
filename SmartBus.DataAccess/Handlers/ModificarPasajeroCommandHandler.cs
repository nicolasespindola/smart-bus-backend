using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartBus.Entities.Factories;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarPasajeroCommandHandler : CommandHandler<ModificarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        private readonly IPasajeroFactory pasajeroFactory;

        public ModificarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext, IPasajeroFactory _pasajeroFactory)
            : base(_session)
        {
            userContext = _userContext;
            pasajeroFactory = _pasajeroFactory;
        }

        public override Task<Pasajero> ResolverCommand(ModificarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var pasajero = pasajeroFactory.Modificar(command.Id, 
                                                     command.Nombre, 
                                                     command.Apellido, 
                                                     command.FechaNacimiento, 
                                                     command.Telefono,
                                                     command.Domicilio, 
                                                     command.PisoDepartamento,
                                                     command.EmailTutores, 
                                                     userContext.NombreUsuario);

            return Task.FromResult(pasajero);
        }

    }
}
