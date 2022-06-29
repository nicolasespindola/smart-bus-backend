using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NHibernate;
using smart_bus_backend.Context;
using smart_bus_backend.Middleware;
using SmartBus.Authentification;
using SmartBus.DataAccess.Context;
using SmartBus.DataAccess.Helpers;
using SmartBus.DataAccess.Repositorios;
using SmartBus.Entities;
using SmartBus.Entities.Factories;

namespace smart_bus_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "smart_bus_backend", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        System.Array.Empty<string>()
                    }
                });
            });
            
            var sessionFactory = NHibernateConfigurationHelper.CreateSessionFactory(Configuration);

            services.AddSingleton(sessionFactory);
            services.AddHttpContextAccessor();
            services.AddScoped<ISession>(factory => sessionFactory.OpenSession());
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IWebUserContext, WebUserContext>();

            services.AddScoped<IEntityLoader, EntityLoader>();
            services.AddScoped<IEventualidadFactory, EventualidadFactory>();
            services.AddScoped<IRecorridoFactory, RecorridoFactory>();

            services.AddMediatR(typeof(NHibernateConfigurationHelper).Assembly);
            services.AddMediatR(typeof(JwtUtils).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "smart_bus_backend v1"));
            }

            app.UseRouting();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
