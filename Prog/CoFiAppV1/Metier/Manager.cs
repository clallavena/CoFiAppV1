using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Manager
    {

        /// <summary>
        /// Utilisateur avec les droits administrateurs
        /// </summary>
        public Admin CurrentUser
        {
            get; private set;
        }

        /// <summary>
        /// Liste de tous les films
        /// </summary>
        public List<Film> Films
        {
            get; private set;
        }


        public IRecherchePersonne rech = new RechParFilm();

        public IDataManager dm;

        public Manager(IDataManager dm)
        {
            this.dm = dm;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un film
        /// </summary>
        /// <param name="film"></param>
        public void AjouterFilm(Film film)
        {
            
        }

        /// <summary>
        /// Méthode permettant d'ajouter une personne qui est un réalisateur
        /// </summary>
        /// <param name="real"></param>
        public void AjouterReal(Personne real)
        {

        }

        /// <summary>
        /// Méthode permettant de signaler un film si le contenu de celui n'est pas approprié
        /// </summary>
        /// <param name="film"></param>
        public void SignalerFilm(Film film)
        {

        }
        
        /// <summary>
         /// Méthode permettant de signaler une personne qui est un réalisateur si le contenu de celui n'est pas approprié
         /// </summary>
         /// <param name="real"></param>
        public void SignalerReal(Personne real)
        {

        }

        /// <summary>
        /// Méthode permettant de rechercher parmi les personnes pour trouver un réalisateur
        /// </summary>
        /// <param name="recherche"></param>
        public Personne RechercherReal(string nom, string prenom)
        {
            return null;
        }

        /// <summary>
        /// Méthode permettant de rechercher parmi la liste des films selon le titre de celui-ci
        /// </summary>
        /// <param name="recherche"></param>
        public Film RechercherFilm(string recherche)
        {
            return null;
        }

        /// <summary>
        /// Méthode permettant de supprimer un film
        /// </summary>
        /// <param name="film"></param>
        public void SupprimerFilm(Film film)
        {

        }

        /// <summary>
        /// Méthode permettant de supprimer une personne qui est un réalisateur
        /// </summary>
        /// <param name="real"></param>
        public void SupprimerReal(Personne real)
        {

        }

        /// <summary>
        /// Méthode permettant de modifier les informations d'un film
        /// </summary>
        /// <param name="film"></param>
        public void ModifierFilm(Film film)
        {

        }

        /// <summary>
        /// Méthode permettant de modifier les informations d'un réalisateur
        /// </summary>
        /// <param name="real"></param>
        public void ModiferReal(Personne real)
        {

        }
    }
}
