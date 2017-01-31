using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Userflux
{
    class Data
    {
        private int id;
        private int user_id;
        private string data_string;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public string Data_string
        {
            get
            {
                return data_string;
            }

            set
            {
                data_string = value;
            }
        }
    }
}
