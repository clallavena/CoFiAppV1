using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.RechercheFilms
{
    public class RechFilmParNom : IRechercheFilm
    {
        public IEnumerator<Film> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche un film, avec en paramètre un critère et une collection de film, recherche à partir du titre du film : Renvoie une liste de Film contenant critère en titre.
        /// </summary>
        /// <param name="critere"></param>
        /// <param name="films"></param>
        /// <returns></returns>
        public IEnumerable<Film> RechercheFilm(string critere, IEnumerable<Film> films)
        {

            return films.Where(s => s.Titre.StartsWith(critere));

        }
    }
}
