using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IRecherchePersonne
    {

        IEnumerable<Film> RechercherRealisateur(string nom, IEnumerable<Film> films);

        IEnumerable<Film> RechercherRealisateur(string nom, string prenom, IEnumerable<Film> films);

    }
}
