﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartBus.Entities;
using System;
using System.Linq;

namespace SmartBus.Authentification
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Usuario)context.HttpContext.Items["User"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Usted no se encuentra autorizado a acceder a este recurso." }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
