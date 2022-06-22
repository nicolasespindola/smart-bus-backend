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
    public class ModificarEscuelaCommandHandler : CommandHandler<ModificarEscuelaCommand, Escuela>
    {
        private readonly IWebUserContext userContext;
        public ModificarEscuelaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Escuela> ResolverCommand(ModificarEscuelaCommand command, CancellationToken cancellationToken)
        {
            var escuela = session.Get<Escuela>(command.Id);


            escuela.Nombre = command.Nombre;
            escuela.Direccion = command.Direccion;
            escuela.UsuarioModificacion = userContext.NombreUsuario;
            escuela.FechaModificacion = DateTime.Now;
            

            return Task.FromResult(escuela);
        }

    }
}
