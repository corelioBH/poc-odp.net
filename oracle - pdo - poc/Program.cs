using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace oracle___pdo___poc
{
    class Program
    {
        static string user = "system";
        static string password = "oracle";
        static string addr = "localhost";
        static string db_name = "PEOPLE";

        static void create(OracleConnection con)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();




            OracleCommand cmd = con.CreateCommand();
            OracleTransaction txn = con.BeginTransaction();

            try
            {
                cmd.CommandText = "INSERT INTO  " + db_name +
                                  " (name) VALUES (:1)";


                OracleParameter name = new OracleParameter();
                name.OracleDbType = OracleDbType.Char;
                name.Value = nome;

                cmd.Parameters.Add(name);

                cmd.ExecuteNonQuery();

                txn.Commit();
                name.Dispose();
                Console.WriteLine("Comando executado com sucesso!");

            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                txn.Rollback();
            }



            cmd.Dispose();

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

        }
        static void retrieve(OracleConnection con)
        {

            Console.Clear();

            OracleCommand cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM "+db_name;

            using (OracleDataReader row = cmd.ExecuteReader())
            {
                while (row.Read())
                {
                    Console.WriteLine(row.GetValue(0) + "\t" + row.GetValue(1));
                }
            }



            cmd.Dispose();

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();



        }
        static void update(OracleConnection con)
        {
            Console.Clear();
            Console.WriteLine("Digite o ID");
            string id_string = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Digite o novo nome");
            string nome = Console.ReadLine();




            OracleCommand cmd = con.CreateCommand();
            OracleTransaction txn = con.BeginTransaction();

            try
            {
                cmd.CommandText = "UPDATE  " + db_name +
                                  " SET name = :1 WHERE id = :2";

                OracleParameter name = new OracleParameter();
                name.OracleDbType = OracleDbType.Char;
                name.Value = nome;
                cmd.Parameters.Add(name);


                OracleParameter id = new OracleParameter();
                id.OracleDbType = OracleDbType.Int32;
                id.Value = Int32.Parse(id_string);
                cmd.Parameters.Add(id);


                Console.WriteLine("Comando executado com sucesso!");

                cmd.ExecuteNonQuery();
                txn.Commit();
                name.Dispose();
                id.Dispose();

            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                txn.Rollback();
            }



            cmd.Dispose();

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();


        }
        static void delete(OracleConnection con)
        {
            Console.Clear();
            Console.WriteLine("Digite o ID");
            string id_string = Console.ReadLine();


            OracleCommand cmd = con.CreateCommand();
            OracleTransaction txn = con.BeginTransaction();

            try
            {
                cmd.CommandText = "DELETE FROM  " + db_name +
                                  " WHERE id = :1";

                OracleParameter id = new OracleParameter();
                id.OracleDbType = OracleDbType.Int32;
                id.Value = Int32.Parse(id_string);
                cmd.Parameters.Add(id);



                cmd.ExecuteNonQuery();
                txn.Commit();
                Console.WriteLine("Comando executado com sucesso!"); 

            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                txn.Rollback();
            }



            cmd.Dispose();

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();



        }
        static void menu(OracleConnection con)
        {

            int escolha;

            do
            {

                Console.Clear();

                Console.WriteLine("Escolha uma opcao:\n1 - Criar\n2 - Lista todos\n3 - Alterar\n4 - Excluir\n9 - Versao do banco de dados\n0 - Sair");
                var lido = Console.ReadLine();
                Int32.TryParse(lido, out escolha);


                switch (escolha)
                {
                    case 1:
                        create(con);
                        break;
                    case 2:
                        retrieve(con);
                        break;
                    case 3:
                        update(con);
                        break;
                    case 4:
                        delete(con);
                        break;
                    case 9:
                        Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    default:
                        break;


                }

            } while (escolha != 0);

            Console.Clear();
            Console.WriteLine("Pressione ENTER para sair...");
            Console.ReadLine();


        }
        static void Main(string[] args)
        {

            try
            {

                string constr = string.Concat(string.Concat(string.Concat("user id=", user), string.Concat(";password=", password)), string.Concat(";data source=", addr));
                OracleConnection con = new OracleConnection(constr);
                con.Open();
                // Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);



                menu(con);




                con.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
                Console.ReadLine();

            }
        }
    }
}

