using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Data
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
