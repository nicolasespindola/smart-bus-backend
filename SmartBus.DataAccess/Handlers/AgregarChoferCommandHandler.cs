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
    public class AgregarChoferCommandHandler : CommandHandler<AgregarChoferCommand, Chofer>
    {
        private readonly IWebUserContext userContext;
        public AgregarChoferCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Chofer> ResolverCommand(AgregarChoferCommand command, CancellationToken cancellationToken)
        {
            

            var nuevoChofer = new Chofer
            {
                Nombre = command.Nombre, 
                Email = command.Email,
                Contraseña = command.Contraseña,
                UsuarioCreacion = userContext.NombreUsuario,
                FechaCreacion = DateTime.Now,
                Eliminado = false,
                
            };

            return Task.FromResult(nuevoChofer);
        }

    }
}
