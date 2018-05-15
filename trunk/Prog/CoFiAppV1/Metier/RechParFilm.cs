using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// Classe qui permet de rechercher un réalisateur en passant par la liste des films puis par la liste des personnes associé à chacun
    /// </summary>
    public class RechParFilm : IRecherchePersonneParCritere
    {
        /// <summary>
        /// Rechercher un réalisateur grâce à son nom et son prénom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns></returns>
        public Personne RechercherRealisateur(string nom, string prenom)
        {
           



            return null;
        }

        /// <summary>
        /// Recherche un réalisateur grâce à son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Personne RechercherRealisateur(string nom)
        {
            return null;
        }
    }
}
