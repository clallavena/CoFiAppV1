using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.RechercheFilms
{
    public interface IRechercheFilm
    {
        Film RechercheFilm(string critere, IEnumerable<Film> films);

    }
}
