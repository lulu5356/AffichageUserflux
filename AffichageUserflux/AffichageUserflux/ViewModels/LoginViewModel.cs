using AffichageUserflux.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Userflux;
using DB;

namespace AffichageUserflux.ViewModels
{
    class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new User();
            loginpage = new LoginPage();
            loginpage.button.Click += Button_Click;
            Application.Current.Windows.OfType<Window>().FirstOrDefault().Content = loginpage;
            loginpage.DataContext = this;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Mysql bdd = new Mysql();
            User loggedUser = bdd.getUser(loginpage.textBox.Text, loginpage.passwordBox.Password);

            loginpage.NavigationService.Navigate(new AddDataPage(loggedUser));

            //throw new NotImplementedException();
        }

        private User _user;
        private LoginPage loginpage;

        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
    }
}
