using MediatR;
using Microsoft.AspNetCore.Http;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBus.Authentification
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISessionFactory sessionFactory;

        public JwtMiddleware(RequestDelegate next, IMediator _mediator, ISessionFactory _sessionFactory)
        {
            _next = next;
            sessionFactory = _sessionFactory;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var idUsuario = jwtUtils.ValidateToken(token);
            if (idUsuario != null)
            {
                // TODO: Revisar si se puede usar un query en vez de llamar al sessionFactory
                var user = sessionFactory.OpenSession().Query<Usuario>().SingleOrDefault(usuario => usuario.Id == idUsuario.Value && !usuario.Eliminado);
                context.Items["User"] = user;

                //userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
