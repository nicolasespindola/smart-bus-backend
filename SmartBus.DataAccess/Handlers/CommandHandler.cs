using MediatR;
using NHibernate;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public abstract class CommandHandler<TCommand, TRespuesta> : IRequestHandler<TCommand, TRespuesta>
        where TCommand : IRequest<TRespuesta> where TRespuesta : IBaseEntity
    {
        internal readonly ISession session;
        public CommandHandler(ISession _session)
        {
            session = _session;
        }

        public abstract Task<TRespuesta> ResolverCommand(TCommand command, CancellationToken cancellationToken);
        public async Task<TRespuesta> Handle(TCommand command, CancellationToken cancellationToken)
        {
            TRespuesta respuesta;

            using(var transaccion = session.BeginTransaction())
            {
                PreResolverCommand(command);

                respuesta = await ResolverCommand(command, cancellationToken);
                
                session.SaveOrUpdate(respuesta);

                PostResolverCommand(respuesta);
                
                transaccion.Commit();
            }

            return respuesta;
        }

        public virtual void PostResolverCommand(TRespuesta respuesta) { }
        public virtual void PreResolverCommand(TCommand command) { }
    }
}
