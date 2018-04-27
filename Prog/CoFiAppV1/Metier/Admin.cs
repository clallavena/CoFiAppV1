using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Admin
    {
        public string Username {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void SupprimerFilm(Film film)
        {

        }

        public void SupprimerReal(Realisateur real)
        {

        }

        public void ModifierFilm(Film film, string titre, int dateDeSortie, string synopsis, params string[] listTags)
        {

        }

        public void ModiferReal(Realisateur real, string nom, string prenom, DateTime dateDeNaissance, DateTime dateDeMort, string nationalite, string biographie)
        {

        }

    }
}
