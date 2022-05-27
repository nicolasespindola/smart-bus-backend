using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
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
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently
                    .Configure()
                    .Database
                    (
                        MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Database=smart-bus-database;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False")
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfigurationHelper>())
                    .BuildSessionFactory();
        }
    }
}
