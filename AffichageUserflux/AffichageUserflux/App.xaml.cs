using AffichageUserflux.ViewModels;
using AffichageUserflux.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace AffichageUserflux
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            NavigationWindow myWindow = new NavigationWindow();
            myWindow.Content = new LoginPage();
            myWindow.ShowsNavigationUI = false;
            myWindow.Show();
        }
        void start(object sender, StartupEventArgs e)
        {
            LoginViewModel loginpage = new LoginViewModel();
        }
    }
}
