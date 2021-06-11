using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova7_CatalinaDorneanu
{
    class DbConnectedMode
    {
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;" +
         "Initial Catalog = Exception;" +
         "integrated Security=true;";

        public static void Connection(out SqlConnection connection, out SqlCommand command)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Connessione al database non avvenuta");
                Console.WriteLine($"Messaggio: {sqlex.Message}");
                connection = null;
                command = null;
                throw;
            }
        }
        public static void GetAll()
        {
            try
            {
                Connection(out SqlConnection connection, out SqlCommand command);

                command.CommandText = "SELECT  * from dbo.Utenti;";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var username = reader[1];

                    Console.WriteLine($"Username: {username}  \n");
                }
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connessione al database non avvenuta");
                Console.WriteLine(e.Message);
            }
        }
        public static void GetUsername()
        {
            try
            {
                Connection(out SqlConnection connection, out SqlCommand command);
                Console.WriteLine("Inserisci lo username desiderato");
                string input = Console.ReadLine();

                if (UsernameExists(input) == false)
                {
                    throw new UserNotFoundException();
                }
                else
                {
                    Console.WriteLine("Utente presente");
                    GetAll();
                }
                connection.Close();
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine("Utente non presente");
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static bool UsernameExists(string input)
        {
            try
            {
                Connection(out SqlConnection connection, out SqlCommand command);
                command.CommandText = "SELECT Username FROM dbo.Utenti WHERE Username = @Username;";
                command.Parameters.AddWithValue("@Username", input);
                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    connection.Close();
                    return false;
                }
                else
                {
                    connection.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
