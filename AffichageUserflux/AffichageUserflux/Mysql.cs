using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Userflux;

namespace AffichageUserflux
{
    class Mysql
    {
        private MySqlConnection connection;
        
        public Mysql()
        {
            string connectionString = "SERVER=127.0.0.1; DATABASE=csharp; UID=root; PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }

        public void AddUser(User user)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO app_user (login, password, firstname, lastname) VALUES (@login, @password, @firstname, @lastname)";
            cmd.Parameters.AddWithValue("@login", user.Login);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@lastname", user.Lastname);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public User getUser(string login, string password)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM app_user WHERE login = '"+ login +"' AND password = '" + password + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            User u = new User();
            while (reader.Read())
            {
                u.Firstname = (string)reader["firstname"];
                u.Lastname = (string)reader["lastname"];
            }
            this.connection.Close();

            return u;
        }
    }
}
