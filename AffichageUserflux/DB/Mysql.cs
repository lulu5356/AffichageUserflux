using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Userflux;

namespace DB
{
    public class Mysql
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
                u.Id = (int)reader["id"];
                u.Login = (string)reader["login"];
                u.Firstname = (string)reader["firstname"];
                u.Lastname = (string)reader["lastname"];
            }
            this.connection.Close();

            return u;
        }

        public void AddData(Data data)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO app_data (user_id, data_string) VALUES (@user_id, @data_string)";
            cmd.Parameters.AddWithValue("@user_id", data.User_id);
            cmd.Parameters.AddWithValue("@data_string", data.Data_string);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public List<Data> getDataUser(User user)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM app_data WHERE user_id = '"+ user.Id +"'";
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Data> list = new List<Data>();
            while (reader.Read())
            {
                Data data = new Data();

                data.User_id = (int)reader["user_id"];
                data.Data_string = (string)reader["data_string"];

                list.Add(data);
            }
            this.connection.Close();

            return list;
        }
    }
}
