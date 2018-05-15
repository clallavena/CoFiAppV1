using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IRecherchePersonne
    {

        Personne RechercherRealisateur(string nom);

        Personne RechercherRealisateur(string nom, string prenom);

    }
}
