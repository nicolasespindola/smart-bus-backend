using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarPasajeroCommandHandler : IRequestHandler<EliminarPasajeroCommand, int>
    {
        private readonly ISession session;

        public EliminarPasajeroCommandHandler(ISession _session)
        {
            session = _session;
        }

        public Task<int> Handle(EliminarPasajeroCommand request, CancellationToken cancellationToken)
        {
            var pasajero = session.Get<Pasajero>(request.Id);

            using (var transaction = session.BeginTransaction())
            {

                pasajero.Eliminado = true;

                session.SaveOrUpdate(pasajero);
                transaction.Commit();
            }

            return Task.FromResult(pasajero.Id);
        }
    }
}
