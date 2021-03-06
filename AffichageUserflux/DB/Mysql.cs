﻿using System;
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
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    u.Id = (int)reader["id"];
                    u.Login = (string)reader["login"];
                    u.Firstname = (string)reader["firstname"];
                    u.Lastname = (string)reader["lastname"];
                }
            }
            else
            {
                u = null;
            }
            this.connection.Close();

            return u;
        }

        public List<User> getAllUsers()
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM app_user";
            MySqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User u = new User();

                u.Id = (int)reader["id"];
                u.Login = (string)reader["login"];
                u.Firstname = (string)reader["firstname"];
                u.Lastname = (string)reader["lastname"];

                users.Add(u);
            }
            this.connection.Close();

            return users;
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

        public void updateData(Data data)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "UPDATE app_data SET data_string=@data_string WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", data.Id);
            cmd.Parameters.AddWithValue("@data_string", data.Data_string);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }


        public List<Data> getDataUser(int user_id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM app_data WHERE user_id = "+ user_id;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Data> list = new List<Data>();
            while (reader.Read())
            {
                Data data = new Data();

                data.Id = (int)reader["id"];
                data.User_id = (int)reader["user_id"];
                data.Data_string = (string)reader["data_string"];

                list.Add(data);
            }
            this.connection.Close();

            return list;
        }

        public Data getData(int data_id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM app_data WHERE id = " + data_id;
            MySqlDataReader reader = cmd.ExecuteReader();
            Data d = new Data();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    d.Id = (int)reader["id"];
                    d.User_id = (int)reader["user_id"];
                    d.Data_string = (string)reader["data_string"];
                }
            }
            else
            {
                d = null;
            }
            this.connection.Close();

            return d;
        }

    }
}
