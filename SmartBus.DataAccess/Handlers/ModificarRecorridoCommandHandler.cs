﻿using System.Threading;
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
    public class ModificarRecorridoCommandHandler : CommandHandler<ModificarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        public ModificarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Recorrido> ResolverCommand(ModificarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var recorrido = session.Get<Recorrido>(command.Id);

            recorrido.Nombre = command.Nombre;
            recorrido.EsRecorridoDeIda = command.EsRecorridoDeIda;
            recorrido.Horario = command.Horario;
            recorrido.Escuela = command.IdEscuela.HasValue ? session.Get<Escuela>(command.IdEscuela) : null;
            recorrido.AñoCreacion = DateTime.Now.Year;
            recorrido.UsuarioModificacion = userContext.NombreUsuario;
            recorrido.FechaModificacion = DateTime.Now;
            recorrido.Pasajeros = SetearPasajeros(command.Pasajeros.Select(p => p.IdPasajero));

            var ordenPasajeros = session.Query<OrdenPasajero>().Where(op => op.IdRecorrido == recorrido.Id);

            foreach(var ordenPasajero in ordenPasajeros)
            {
                session.Delete(ordenPasajero);
            }

            foreach(var ordenPasajeroNuevo in command.Pasajeros)
            {
                session.SaveOrUpdate(new OrdenPasajero()
                {
                    IdRecorrido = recorrido.Id,
                    IdPasajero = ordenPasajeroNuevo.IdPasajero,
                    Orden = ordenPasajeroNuevo.Orden
                });
            }

            return Task.FromResult(recorrido);
        }

        private List<Pasajero> SetearPasajeros(IEnumerable<int> idPasajeros)
        {
            return session.Query<Pasajero>()
                .Where(p => idPasajeros.Contains(p.Id) && !p.Eliminado)
                .ToList();
        }

        public override void PreResolverCommand(ModificarRecorridoCommand command)
        {
            var recorrido = session.Get<Recorrido>(command.Id);
            var pasajerosViejo = recorrido.Pasajeros.Select(p => p.Id);
            var pasajerosNuevo = command.Pasajeros.Select(p => p.IdPasajero);

            var idPasajerosEliminados = pasajerosViejo.Except(pasajerosNuevo);
            var idPasajerosAgregados = pasajerosNuevo.Except(pasajerosViejo);

            if(idPasajerosEliminados.Any())
                EliminarEstadosDeCuenta(command.Id, idPasajerosEliminados);

            if (idPasajerosAgregados.Any())
                AgregarEstadosDeCuenta(command.Id, idPasajerosAgregados);
        }

        private void EliminarEstadosDeCuenta(int idRecorrido, IEnumerable<int> idPasajerosEliminados)
        {
            var estadosDeCuentaAEliminar = session.Query<EstadoDeCuenta>().Where(ec => !ec.Eliminado 
                && ec.IdRecorrido == idRecorrido 
                && idPasajerosEliminados.Contains(ec.IdPasajero));

            if(estadosDeCuentaAEliminar.Any())
            {
                foreach (var estadoDeCuenta in estadosDeCuentaAEliminar)
                {
                    estadoDeCuenta.Eliminado = true;
                    estadoDeCuenta.FechaEliminacion = DateTime.Now;
                    estadoDeCuenta.UsuarioEliminacion = userContext.NombreUsuario;
                    session.SaveOrUpdate(estadoDeCuenta);
                }
            }
        }

        private void AgregarEstadosDeCuenta(int idRecorrido, IEnumerable<int> idPasajerosAgregados)
        {
            foreach (var idPasajero in idPasajerosAgregados)
            {
                if (session.Query<EstadoDeCuenta>().Any(ec => !ec.Eliminado && ec.IdRecorrido == idRecorrido && ec.IdPasajero == idPasajero))
                {
                    throw new ApplicationException(
                        $"Error al intentar generar un nuevo estado de cuenta para el pasajero id = {idPasajero} y recorrido id = {idRecorrido}. " +
                        $"Se encontro un estado de cuenta ya existente.");
                }

                var estadoDeCuenta = new EstadoDeCuenta(idRecorrido, idPasajero)
                {
                    UsuarioCreacion = userContext.NombreUsuario,
                    FechaCreacion = DateTime.Now
                };

                session.SaveOrUpdate(estadoDeCuenta);
            }
        }
    }
}
