using AffichageUserflux.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Userflux;
using System.Windows;

namespace AffichageUserflux.ViewModels
{
    class RegisterViewModel
    {
        public RegisterViewModel()
        {
            User = new User();
            registerpage = new RegisterPage();
            registerpage.button.Click += Button_Click;
            registerpage.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Login = registerpage.login.Text;
            user.Password = registerpage.password.Text;
            user.Firstname = registerpage.firstname.Text;
            user.Lastname = registerpage.lastname.Text;

            Mysql bdd = new Mysql();
            bdd.AddUser(user);

            registerpage.NavigationService.Navigate(new RegisterPage());

            throw new NotImplementedException();
        }

        private User user;
        private RegisterPage registerpage;

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }
    }
}
