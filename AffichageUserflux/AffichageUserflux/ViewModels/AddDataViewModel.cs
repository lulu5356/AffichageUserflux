using AffichageUserflux.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userflux;
using DB;
using System.Windows;


namespace AffichageUserflux.ViewModels
{
    class AddDataViewModel
    {
        public AddDataViewModel(User logged)
        {
            Data = new Data();
            user = logged;
            datapage = new AddDataPage(user);
            datapage.button.Click += Button_Click;
            datapage.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.Data_string = datapage.jsonData.Text;
            Data.User_id = user.Id;

            Mysql bdd = new Mysql();
            bdd.AddData(Data);

            datapage.NavigationService.Navigate(new AddDataPage(user));

            throw new NotImplementedException();
        }

        private Data data;
        private User user;
        private AddDataPage datapage;

        public Data Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }
}
