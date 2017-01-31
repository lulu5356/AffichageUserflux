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

        // Constructeur
        public Mysql()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=127.0.0.1; DATABASE=mli; UID=root; PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }

        // Méthode pour ajouter un contact
        public void AddUser(User user)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO app_user (login, password, firstname, lastname) VALUES (@login, @password, @firstname, @lastname)";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
        }
    }
}
