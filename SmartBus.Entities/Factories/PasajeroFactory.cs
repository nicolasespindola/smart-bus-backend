using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public class PasajeroFactory : IPasajeroFactory
    {
        private readonly IEntityLoader entityLoader;

        public PasajeroFactory(IEntityLoader _entityLoader)
        {
            entityLoader = _entityLoader;
        }
        public Pasajero Crear(string nombre, string apellido, DateTime fechaNacimiento, string telefono, Direccion domicilio, string pisoDepartamento, IEnumerable<string> emailTutores, string usuarioCreacion)
        {
            var nuevoPasajero = new Pasajero
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                Telefono = telefono,
                Domicilio = domicilio,
                PisoDepartamento = pisoDepartamento,
                Eventualidades = new List<Eventualidad>(),
                Tutores = ActualizarTutores(emailTutores),
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = usuarioCreacion
            };

            return nuevoPasajero;
        }

        public Pasajero Modificar(int id, string nombre, string apellido, DateTime fechaNacimiento, string telefono, Direccion domicilio, string pisoDepartamento, IEnumerable<string> emailTutores, string usuarioModificacion)
        {
            var pasajero = entityLoader.Load<Pasajero>(id);

            pasajero.Nombre = nombre;
            pasajero.Apellido = apellido;
            pasajero.FechaNacimiento = fechaNacimiento;
            pasajero.Telefono = telefono;
            pasajero.Domicilio = domicilio;
            pasajero.PisoDepartamento = pisoDepartamento;
            pasajero.Tutores = ActualizarTutores(emailTutores);
            pasajero.FechaModificacion = DateTime.Now;
            pasajero.UsuarioModificacion = usuarioModificacion;

            return pasajero;
        }

        private IEnumerable<Usuario> ActualizarTutores(IEnumerable<string> emailTutores)
        {
            var tutoresAsignables = entityLoader.Query<Usuario>().Where(u => !u.Eliminado && emailTutores.Contains(u.Email));
            var emailTutoresAsignables = tutoresAsignables.Select(t => t.Email);

            var tutoresNuevos = emailTutores.Except(emailTutoresAsignables).Select(t => new Usuario() { Email = t, TipoDeUsuario = Enumerators.TipoDeUsuario.Tutor });

            var tutores = tutoresAsignables.ToList().Concat(tutoresNuevos).ToList();
            return tutores;
        }
    }
}
