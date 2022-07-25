using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public class EscuelaFactory : IEscuelaFactory
    {
        private readonly IEntityLoader entityLoader;

        public EscuelaFactory(IEntityLoader _entityLoader)
        {
            entityLoader = _entityLoader;
        }

        public Escuela Crear(string nombre, Direccion direccion, IEnumerable<string> emailUsuarios, string usuarioCreacion)
        {
            var nuevaEscuela = new Escuela
            {
                Nombre = nombre,
                Direccion = direccion,
                UsuarioCreacion = usuarioCreacion,
                FechaCreacion = DateTime.Now,
                Eliminado = false,
                Usuarios = ActualizarUsuarios(emailUsuarios)
            };

            return nuevaEscuela;
        }

        public Escuela Modificar(int idEscuela, string nombre, Direccion direccion, IEnumerable<string> emailUsuarios, string nombreUsuario)
        {
            var escuela = entityLoader.Load<Escuela>(idEscuela);

            escuela.Nombre = nombre;
            escuela.Direccion = direccion;
            escuela.UsuarioModificacion = nombreUsuario;
            escuela.FechaModificacion = DateTime.Now;
            escuela.Usuarios = ActualizarUsuarios(emailUsuarios);

            return escuela;
        }

        private IEnumerable<Usuario> ActualizarUsuarios(IEnumerable<string> emailUsuarios)
        {
            var usuariosAsignables = entityLoader.Query<Usuario>().Where(u => !u.Eliminado && emailUsuarios.Contains(u.Email));
            
            if(usuariosAsignables.Any() && usuariosAsignables.Any(u => u.TipoDeUsuario != TipoDeUsuario.Escuela))
            {
                throw new ApplicationException("Todos los mails asignados deben corresponder a un usuario del tipo escuela.");
            }

            var emailUsuariosAsignables = usuariosAsignables.Select(t => t.Email);

            var usuariosNuevos = emailUsuarios.Except(emailUsuariosAsignables).Select(t => new Usuario() { Email = t, TipoDeUsuario = Enumerators.TipoDeUsuario.Escuela });

            var usuarios = usuariosAsignables.ToList().Concat(usuariosNuevos).ToList();
            return usuarios;
        }
    }
}
