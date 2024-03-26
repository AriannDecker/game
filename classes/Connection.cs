using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace game.classes
{
    internal class Connection
    {
        private static MySqlConnection connection = new MySqlConnection(secret.connStr);

        public static bool submission(string fName, string lName, string email, string userName)
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO players(fName,lName,email,userName) VALUES (?fName,?lName,?email,?userName)";
                command.Parameters.Add("?fName", MySqlDbType.VarChar).Value = fName;
                command.Parameters.Add("?lName", MySqlDbType.VarChar).Value = lName;
                command.Parameters.Add("?email", MySqlDbType.VarChar).Value = email;
                command.Parameters.Add("?userName", MySqlDbType.VarChar).Value = userName;

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static userScore[] populate()
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT players.userName, score FROM mathmadness_db.players INNER JOIN scoreboard ON players.userName = scoreboard.userName ORDER BY scoreboard.score;";
                var reader = command.ExecuteReader();

                var list = new List<userScore>();


                while (reader.Read())
                {
                    list.Add(new userScore(reader.GetString(0), reader.GetInt32(1)));
                }
                connection.Close();
                return list.ToArray();

            } catch
            {
                return new userScore[] { };
            }
        }

        public static bool addScore(string userName, int score)
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO scoreboard (userName, score) VALUES (?userName, ?score)";
                command.Parameters.Add("?userName", MySqlDbType.VarChar).Value = userName;
                command.Parameters.Add("?score", MySqlDbType.Int32).Value = score;

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
