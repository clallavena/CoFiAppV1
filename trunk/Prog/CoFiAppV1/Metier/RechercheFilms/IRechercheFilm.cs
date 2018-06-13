using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.RechercheFilms
{
    public interface IRechercheFilm
    {
        /// <summary>
        /// Rechecher un film
        /// </summary>
        /// <param name="critere"></param>
        /// <param name="films"></param>
        /// <returns></returns>
        IEnumerable<Film> RechercheFilm(string critere, IEnumerable<Film> films);
    }
}
