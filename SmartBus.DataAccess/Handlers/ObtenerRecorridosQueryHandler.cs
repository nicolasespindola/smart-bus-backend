﻿using MediatR;
using NHibernate;
using SmartBus.DataAccess.Context;
using SmartBus.DataAccess.DTOs;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using SmartBus.Entities.Enumerators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class ObtenerRecorridosQueryHandler : IRequestHandler<ObtenerRecorridosQuery, List<RecorridoDTO>>
    {
        private readonly IWebUserContext userContext;
        private readonly ISession session;

        public ObtenerRecorridosQueryHandler(ISession _session, IWebUserContext _userContext)
        {
            session = _session;
            userContext = _userContext;
        }

        public Task<List<RecorridoDTO>> Handle(ObtenerRecorridosQuery request, CancellationToken cancellationToken)
        {
            var recorridos = new List<Recorrido>();
            switch (userContext.TipoDeUsuario)
            {
                case TipoDeUsuario.Tutor:
                    recorridos = session.Query<Recorrido>().Where(r => !r.Eliminado && r.Pasajeros.Any(p => p.Tutores.Any(t => t.Id == userContext.Id))).ToList();
                    recorridos = recorridos.Select(r =>
                        {
                            r.Pasajeros = r.Pasajeros.Where(p => p.Tutores.Any(t => t.Id == userContext.Id));
                            return r;
                        }
                    ).ToList();
                    break;

                case TipoDeUsuario.Chofer:
                    recorridos = session.Query<Recorrido>().Where(r => !r.Eliminado && r.UsuarioCreacion == userContext.NombreUsuario).ToList();
                    break;

                case TipoDeUsuario.Escuela:
                    recorridos = session.Query<Recorrido>().Where(r => !r.Eliminado && r.Escuela.Usuarios.Any(u => u.Id == userContext.Id)).ToList();
                    break;

            }
            var recorridosDTO = recorridos.Select(r => new RecorridoDTO(r)).ToList();
            return Task.FromResult(recorridosDTO);
        }
    }
}
