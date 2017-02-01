using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Userflux;

namespace AffichageUserflux
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User u = new User();
            u.Login = this.login.Text;
            u.Password = this.password.Text;
            u.Firstname = this.firstname.Text;
            u.Lastname = this.lastname.Text;

            Mysql bdd = new Mysql();
            bdd.AddUser(u);

            CreateUserWindow createUser = new CreateUserWindow();
            createUser.Show();

            this.Close();
        }
    }
}
