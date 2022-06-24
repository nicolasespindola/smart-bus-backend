using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace SmartBus.DataAccess.Helpers
{
    public abstract class NHibernateConfigurationHelper
    {
        public static ISessionFactory CreateSessionFactory(IConfiguration configuration)
        {
            return Fluently
                    .Configure()
                    .Database
                    (
                        MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(configuration.GetConnectionString("smart-bus-database"))
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfigurationHelper>())
                    .BuildSessionFactory();
        }
    }
}
