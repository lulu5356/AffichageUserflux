using DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spatial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userflux;

namespace ConsoleUserFlux
{
    class Program
    {
        public static Mysql mysql;
        public static User logged;
        public const int LIMIT_DATA = 5;

        static void Main(string[] args)
        {
            mysql = new Mysql();

            authentication();

            // Display and choice of user
            Console.WriteLine("Liste des utilisateurs :");
            Console.WriteLine(" ");
            displayUsers();
            Console.WriteLine(" ");
            Console.Write("Choisissez un utilisateur : ");
            int target_user = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");

            // Display and choice of data for the previous selected user.
            int target_data;
            do
            {
                displayDatas(mysql.getDataUser(target_user));
                Console.Write("Sélectionnez une data à modifier (0 to exit) : ");
                target_data = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
                if(target_data != 0)
                {
                    updateData(target_data);
                }
            } while (target_data != 0);
            
        }

        public static void authentication()
        {
            string login;
            string password;
            Console.WriteLine("Authentication required");
            Console.WriteLine(" ");

            do
            {
                password = "";
                Console.Write("Login : ");
                login = Console.ReadLine();
                Console.Write("Password : ");
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        password += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                while (keyInfo.Key != ConsoleKey.Enter);
                logged = mysql.getUser(login, password);
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                if (logged == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong login/password");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Authenticated under " + logged.Firstname + " " + logged.Lastname);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                }
            } while (logged == null);
            Console.WriteLine(" ");
            Console.WriteLine("*****************************");
            Console.WriteLine("");
        }

        public static void displayUsers()
        {
            List<User> users = mysql.getAllUsers();

            users.ForEach(user =>
            {
                Console.WriteLine(user.Id + ".\t" + user.Firstname + " " + user.Lastname);
            });
        }

        public static void displayDatas(List<Data> datas)
        {
            datas.ForEach(data =>
            {
                Console.WriteLine("Data N°" + data.Id + " :\n" + data.Data_string);
                Console.WriteLine(" ");
                Console.WriteLine("*****************************");
                Console.WriteLine(" ");
            });
        }

        public static void updateData(int data_id)
        {
            Data data = mysql.getData(data_id);
            if(data != null)
            {
            JObject jo = JObject.Parse(data.Data_string);
            JObject temp = new JObject();
            string temp_value;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Leave the field empty to remove.");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (JProperty property in jo.Properties())
            {
                if(!property.Name.Equals("id"))
                {
                    Console.Write(property.Name + " : ");
                    temp_value = Console.ReadLine();
                    if(!temp_value.Equals(""))
                    {
                        temp.Add(new JProperty(property.Name, temp_value));
                    }
                }
            }

            temp = addJsonFields(temp);
            data.Data_string = temp.ToString();

            mysql.updateData(data);

            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Data Updated !");
            Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The data with this id doesn't exist.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
            }
        }

        public static JObject addJsonFields(JObject jo)
        {
            Console.Write("Add fields to the object ? (y/n) ");
            string rep = Console.ReadLine();
            string field;
            string value;

            if(rep.Equals("y"))
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Leave empty the field to stop adding data.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                
                do
                {
                    Console.Write("Field : ");
                    field = Console.ReadLine();
                    if (!field.Equals(""))
                    {
                        Console.Write("Value : ");
                        value = Console.ReadLine();
                        jo.Add(new JProperty(field, value));
                    }
                } while (!field.Equals(""));
            }
            return jo;
        }
    }
}
