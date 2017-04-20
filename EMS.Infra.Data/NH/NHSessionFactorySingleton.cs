using EMS.Infra.Data.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace EMS.Infra.Data.NH
{
    public static class NHSessionFactorySingleton
    {
        private static ISessionFactory sessionFactory = null;
        private static object lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObj)
                {
                    if (sessionFactory == null)
                    {
                        sessionFactory = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("EMS")).ShowSql())                                
                                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(EmployeeMap))))
                                .BuildSessionFactory();
                    }
                }
                return sessionFactory;
            }
        }
    }
}
