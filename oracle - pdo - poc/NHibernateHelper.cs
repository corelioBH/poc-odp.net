using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Oracle.SqlAndPlsqlParser.LocalParsing;
using OracleInternal.Common;
using Oracle.ManagedDataAccess.Client;
using NHibernate.Cfg;
using System;

namespace Crud_FluentNHibernate.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + oracle___pdo___poc.Program.addr + ")(PORT= 1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id="+ oracle___pdo___poc.Program.user + ";Password="+oracle___pdo___poc.Program.password+";";
      
            //Caso não queira mostrar o SQL a cada envio, retirar .ShowSQL da linha 24
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(OracleManagedDataClientConfiguration.Oracle10
                  .ConnectionString(constr)
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<oracle___pdo___poc.PEOPLE>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();


            return sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration obj)
        {
            throw new NotImplementedException();
        }
    }
}