using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Userflux
{
    class Vehicule
    {
        private int id;
        private string couleur;
        private int puissance;
        private string marque;

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

        public string Couleur
        {
            get
            {
                return couleur;
            }

            set
            {
                couleur = value;
            }
        }

        public int Puissance
        {
            get
            {
                return puissance;
            }

            set
            {
                puissance = value;
            }
        }

        public string Marque
        {
            get
            {
                return marque;
            }

            set
            {
                marque = value;
            }
        }
    }
}
