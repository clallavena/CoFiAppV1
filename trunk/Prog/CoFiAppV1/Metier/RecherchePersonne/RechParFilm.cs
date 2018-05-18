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
    public class RechParFilm : IRecherchePersonne
    {
        /// <summary>
        /// Rechercher un réalisateur grâce à son nom et son prénom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns></returns>
        public IEnumerable<Film> RechercherRealisateur(string nom, string prenom, IEnumerable<Film> films)
        {
            var rech = films.Where(s => s.Personnes.Keys.Contains(Job.Realisateur)
                                      && s.Personnes[Job.Realisateur].Exists(p => p.Nom.Equals(nom) && p.Prenom.Equals(prenom)));

            return rech;
        }

        /// <summary>
        /// Recherche un réalisateur grâce à son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public IEnumerable<Film> RechercherRealisateur(string nom, IEnumerable<Film> films)
        {
            var rech = films.Where(s => s.Personnes.Keys.Contains(Job.Realisateur)
                                      && s.Personnes[Job.Realisateur].Exists(p => p.Nom.Equals(nom)));

            return rech;
        }
    }
}
