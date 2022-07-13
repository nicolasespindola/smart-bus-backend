using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public class RecorridoFactory : IRecorridoFactory
    {
        private readonly IEntityLoader entityLoader;

        public RecorridoFactory(IEntityLoader _entityLoader)
        {
            entityLoader = _entityLoader;
        }

        public Recorrido Crear(string nombre, bool esRecorridoDeIda, DateTime horario, int? idEscuela, int idChofer, string usuarioCreacion, IEnumerable<int> idPasajeros)
        {
            var usuarioChofer = entityLoader.Load<Usuario>(idChofer);

            if(usuarioChofer.TipoDeUsuario != Enumerators.TipoDeUsuario.Chofer)
            {
                throw new ApplicationException($"El IdChofer: {idChofer} no corresponde a un usuario del tipo chofer");
            }

            var nuevoRecorrido =  new Recorrido
            {
                Nombre = nombre,
                EsRecorridoDeIda = esRecorridoDeIda,
                Horario = horario,
                Escuela = idEscuela.HasValue ? entityLoader.Load<Escuela>(idEscuela.Value) : null,
                Chofer = usuarioChofer,
                AñoCreacion = DateTime.Now.Year,
                UsuarioCreacion = usuarioCreacion,
                FechaCreacion = DateTime.Now,
                Pasajeros = SetearPasajeros(idPasajeros),
                Eliminado = false
            };

            nuevoRecorrido = entityLoader.Add(nuevoRecorrido);
            nuevoRecorrido = SetearEstadosDeCuenta(nuevoRecorrido, usuarioCreacion);

            return nuevoRecorrido;
        }

        private List<Pasajero> SetearPasajeros(IEnumerable<int> idPasajeros)
        {
            return entityLoader.Query<Pasajero>()
                .Where(p => idPasajeros.Contains(p.Id) && !p.Eliminado)
                .ToList();
        }

        private Recorrido SetearEstadosDeCuenta(Recorrido recorrido, string usuarioCreacion)
        {
            var estadosDeCuentaNuevos = new List<EstadoDeCuenta>();
            foreach (Pasajero pasajero in recorrido.Pasajeros)
            {
                if (entityLoader.Query<EstadoDeCuenta>().Any(ec => !ec.Eliminado && ec.IdPasajero == pasajero.Id && ec.IdRecorrido == recorrido.Id))
                {
                    throw new ApplicationException($"Ya existe un estado de cuenta para el pasajero Id {pasajero.Id} y recorrido Id {recorrido.Id}.");
                }

                var nuevoEstadoDeCuenta = new EstadoDeCuenta(recorrido.Id, pasajero.Id)
                {
                    UsuarioCreacion = usuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Eliminado = false
                };

                estadosDeCuentaNuevos.Add(nuevoEstadoDeCuenta);
            }

            recorrido.EstadosDeCuenta = estadosDeCuentaNuevos;

            return recorrido;
        }
    }
}
