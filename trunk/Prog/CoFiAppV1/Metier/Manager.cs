using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.RechercheFilms;

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
            get; set;
        }


        private IRecherchePersonne rech = new RechParFilm();
        private IDataManager dm;

        public Manager(IDataManager datamanager)
        {
            dm = datamanager;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un film à la collection existante
        /// </summary>
        /// <param name="film"></param>
        public void AjouterFilm(Film film)
        {
            if (Films.Count == 0)
            {
                Films.Add(film);
                return;
            }

            foreach (Film f in Films)
            {
                //Prevoir un message d'erreur si vrai
                /* if (film.Equals(f))
                 {
                     Debug.WriteLine("Ce film existe déjà");
                     return;
                 }*/
                Film fi;
                fi = RechercherFilm(film.Titre, Films);

                if (fi == null)
                {
                    Films.Add(film);
                    return;
                }
                else
                {
                    Debug.WriteLine("Film existant");
                    return;
                }
            }
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
        public Film RechercherFilm(string recherche, List<Film> Films)
        {
            RechFilmParNom re = new RechFilmParNom();
            return re.RechercheFilm(recherche, Films);
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
