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
        /// Liste des réalisateur connue
        /// </summary>
        private List<Personne> reals = new List<Personne>();

        /// <summary>
        /// Collection de Réalisateur connu de type Personne
        /// </summary>
        public IEnumerable<Personne> ListReal
        {
            get
            {
                return reals;
            }
        }

        /// <summary>
        /// Liste de tous les films
        /// </summary>
        private List<Film> films = new List<Film>();

        public IEnumerable<Film> Films
        {
            get
            {
                return films;
            }
        }

        private Film filmSelected;

        public Film FilmSelected
        {
            get { return filmSelected; }
            set { filmSelected = value; }
        }

        private IRecherchePersonne rech = new RechParFilm();
        IDataManager Dm
        {
            get;
            set;
        }

        public Manager(IDataManager datamanager)
        {
            Dm = datamanager;
        }

        public void Chargement()
        {
            films.AddRange(Dm.ChargementFilms());
            reals.AddRange(Dm.ChargementReal());
        }

        /// <summary>
        /// Méthode permettant d'ajouter un film à la collection existante
        /// </summary>
        /// <param name="film"></param>
        public void AjouterFilm(Film film)
        {
            if (films.Contains(film))
            {
                Debug.WriteLine("Ce film existe déjà");
                return;
            }
            else
            {
                films.Add(film);
            }

        }

        /// <summary>
        /// Méthode permettant d'ajouter une personne qui est un réalisateur dans la collection de réalisateur connu
        /// </summary>
        /// <param name="real"></param>
        public void AjouterReal(Personne real)
        {
            if (reals.Contains(real))
            {
                Debug.WriteLine("Réalisateur Existant");
                return;
            }
            else
            {
                reals.Add(real);
            }
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
        public IEnumerable<Film> RechercherReal(string nom, string prenom)
        {
            IRecherchePersonne re = new RechParFilm();
            return re.RechercherRealisateur(nom, prenom, films);
        }

        /// <summary>
        /// Méthode permettant de rechercher parmi la liste des films selon le titre de celui-ci
        /// </summary>
        /// <param name="recherche"></param>
        public IEnumerable<Film> RechercherFilm(string recherche, List<Film> Films)
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
            if (films.Contains(film))
            {
                films.Remove(film);
            }
            else
            {
                Debug.WriteLine("Film inexistant");
            }

        }

        /// <summary>
        /// Méthode permettant de supprimer une personne qui est un réalisateur
        /// </summary>
        /// <param name="real"></param>
        public void SupprimerReal(Personne real)
        {
            if (reals.Contains(real))
            {
                reals.Remove(real);
            }
            else
            {
                Debug.WriteLine("Réalisateur inexistant");
            }

        }

        /// <summary>
        /// Méthode permettant de modifier les informations d'un film
        /// </summary>
        /// <param name="film"></param>
        public void ModifierFilm(string titre, int dateDeSortie, string synopsis, Dictionary<Job, List<Personne>> personnes, params Tag[] listTags)
        {

            IEnumerable<Film> li = RechercherFilm(titre, films);

            li.Where(s => s.Titre.Equals(titre) && s.DateDeSortie == dateDeSortie);

            if (li.Count() == 1)
            {
                foreach(Film f in li)
                {
                    f.Titre = titre;
                    f.DateDeSortie = dateDeSortie;
                    f.Synopsis = synopsis;

                    f.Personnes.Clear();
                    foreach (KeyValuePair<Job, List<Personne>> p in personnes)
                    {
                        f.Personnes[p.Key].AddRange(p.Value);
                    }

                    foreach (Tag t in listTags)
                    {
                        f.ListTags.Add(t);
                    }
                }
            }
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
