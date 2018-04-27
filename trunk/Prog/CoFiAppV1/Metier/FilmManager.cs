using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    // tout revoir entièrement
    public class FilmManager
    {
        public static List<Film> ListFilms
        {
            get; private set;
        }

        public FilmManager(){ }

        public void AddFilm(Film film)
        {
            foreach(var e in ListFilms)
            {
                if (!e.Equals(film))
                {
                    ListFilms.Add(film);
                }
            }
        }

        public string Affichage()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("------------");
            sb.Append("liste de tous les films : \n");

            foreach(var e in ListFilms)
            {
                sb.Append("\n" + e);
            }

            sb.Append("\n------------");

            return sb.ToString();
        }
    }
}
