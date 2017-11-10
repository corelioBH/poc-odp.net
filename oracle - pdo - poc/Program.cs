using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using FluentNHibernate.Mapping;
using Crud_FluentNHibernate.Models;
using NHibernate;
using NHibernate.Linq;

namespace oracle___pdo___poc
{


    public class PEOPLE
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }


    }
    class Program
    {
        public static string user = "system";
        public static string password = "oracle";
        public static string addr = "192.168.1.171";
        public static string db_name = "PEOPLE";


       
       static void Main(string[] args)
        {

            //Caso queira utilizar a versão anterior, remova o comentário do código

            /*
             string constr = string.Concat(string.Concat(string.Concat("user id=", user), string.Concat(";password=", password)), string.Concat(";data source=", addr));
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);

            Console.ReadLine();
            var prior = new Console_Onecs();
            prior.menu(con);

            */

            List_all();
            Console.ReadLine();

        }
        static void List_all()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {

                var pessoas = session.Query<PEOPLE>().ToArray();
                foreach (var pessoa in pessoas)
                {

                    Console.WriteLine(pessoa.id+"\t"+pessoa.name);

                }

            }


        }

        static void Get_id(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Get<PEOPLE>(id);
                Console.WriteLine(pessoa.id + "\t" + pessoa.name);

            }
        }


        static void Update(int id, string name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var person = session.Get<PEOPLE>(id);

                    person.name = name;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(person);
                        transaction.Commit();
                    }
                }
            }
            catch
            {

                Console.WriteLine("Error!");
            }
        }


        static void Delete(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {

                    var person = session.Get<PEOPLE>(id);


                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(person);
                        transaction.Commit();
                    }
                }
            }
            catch
            {
            }
        }
        
        static void Create(PEOPLE pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoa);
                        transaction.Commit();
                    }
                }
            }
            catch
            {
            }
        }

    }
}

