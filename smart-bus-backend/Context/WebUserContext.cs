using Microsoft.AspNetCore.Http;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_bus_backend.Context
{
    public class WebUserContext : IWebUserContext
    {
        private readonly HttpContext httpContext;

        public WebUserContext(IHttpContextAccessor _httpContextAccessor)
        {
            httpContext = _httpContextAccessor.HttpContext;
        }
        public string NombreUsuario => this.GetNombreUsuario();

        private string GetNombreUsuario()
        {
            var usuario = this.httpContext.Items["User"] as Usuario;

            return usuario.Email;
        }
    }
}
