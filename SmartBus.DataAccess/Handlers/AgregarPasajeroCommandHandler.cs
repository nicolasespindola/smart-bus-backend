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
    public class AgregarPasajeroCommandHandler : IRequestHandler<AgregarPasajeroCommand, Pasajero>
    {
        private readonly ISession session;

        public AgregarPasajeroCommandHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Pasajero> Handle(AgregarPasajeroCommand request, CancellationToken cancellationToken)
        {
            var nuevoPasajero = new Pasajero {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                FechaNacimiento = request.FechaNacimiento,
                Telefono = request.Telefono,
                CalleDomicilio = request.CalleDomicilio,
                NumeroDomicilio = request.NumeroDomicilio,
                PisoDepartamento = request.PisoDepartamento,
                IdentificacionDepartamento = request.IdentificacionDepartamento,
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "nespindola",
            };

            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(nuevoPasajero);
                transaction.Commit();
            }

            return Task.FromResult(nuevoPasajero);
        }
    }
}
