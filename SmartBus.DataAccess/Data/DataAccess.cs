using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Data
{
    public class DataAccess : IDataAccess
    {
        private ISessionFactory _sessionFactory;

        public DataAccess()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently
                    .Configure()
                    .Database
                    (
                        MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Database=smart-bus-database;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False")
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .BuildSessionFactory();
        }

        public List<Pasajero> GetPasajeros()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    var pasajeros = session.CreateCriteria(typeof(Pasajero)).List<Pasajero>();
                    return pasajeros.ToList();
                }
            }
        }

        public Pasajero AddPasajero(PasajeroDTO pasajeroDTO)
        {
            throw new NotImplementedException();
        }
    }
}
