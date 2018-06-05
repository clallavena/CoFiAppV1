using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Metier.RechercheFilms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Metier
{
    public class Manager : INotifyPropertyChanged
    {

        private Admin currentUser;

        /// <summary>
        /// Utilisateur avec les droits administrateurs
        /// </summary>
        public Admin CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        /// <summary>
        /// Liste des Administrateur de l'application
        /// </summary>
        private List<Admin> admins = new List<Admin>();

        private List<Film> filmRecherche = new List<Film>();

        public IEnumerable<Film> ListFilmRecherche
        {
            get
            {
                return filmRecherche;
            }
            set { }
        }

        /// <summary>
        /// Collection d'Administrateur de l'application
        /// </summary>
        public IEnumerable<Admin> ListAdmin
        {
            get
            {
                return admins;
            }
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
        private ObservableCollection<Film> films = new ObservableCollection<Film>();

        public ObservableCollection<Film> Films
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

        public event PropertyChangedEventHandler PropertyChanged;

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
            foreach (Film f in Dm.ChargementFilms())
            {
                films.Add(f);
            }
            FilmsParNom = Films;
            reals.AddRange(Dm.ChargementReal());
            admins.AddRange(Dm.ChargementAdmin());
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
        public void Signaler(Film film)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("cofiappcontact@gmail.com");
            mail.To.Add(new MailAddress("clement.allavena@etu.uca.fr"));
            mail.To.Add(new MailAddress("esteban.barland@etu.uca.fr"));
            mail.Subject = "[CoFiApp] Signalement de Film";
            mail.Body = "Le film " + film.Titre + " a été signalé par un utilisateur !";

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("cofiappcontact@gmail.com", "cofiappmail");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }

        /// <summary>
        /// Méthode permettant de signaler une personne qui est un réalisateur si le contenu de celui n'est pas approprié
        /// </summary>
        /// <param name="real"></param>
        public void Signaler(Personne real)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("cofiappcontact@gmail.com");
            mail.To.Add(new MailAddress("clement.allavena@etu.uca.fr"));
            mail.To.Add(new MailAddress("esteban.barland@etu.uca.fr"));
            mail.Subject = "[CoFiApp] Signalement de Film";
            mail.Body = "Le réalisateur " + real.Nom + " " + real.Prenom + " a été signalé par un utilisateur !";

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("cofiappcontact@gmail.com", "cofiappmail");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

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
        public IEnumerable<Film> RechercherFilm(string recherche, ObservableCollection<Film> Films)
        {
            if(string.IsNullOrWhiteSpace(recherche) || recherche == "Rechercher")
            {
                FilmsParNom = Films;
                return FilmsParNom;
            }
            RechFilmParNom re = new RechFilmParNom();
            FilmsParNom = re.RechercheFilm(recherche, Films).ToList();
            return FilmsParNom;
        }

        public IEnumerable<Film> FilmsParNom
        {
            get => filmsParNom;
            set
            {
                filmsParNom = value;
                NotifyPropertyChanged(nameof(FilmsParNom));
            }
        }
        IEnumerable<Film> filmsParNom;

        /// <summary>
        /// Méthode permettant de supprimer un film
        /// </summary>
        /// <param name="film"></param>
        public bool SupprimerFilm(Film film)
        {
            if (films.Contains(film))
            {
                films.Remove(film);
                return true;
            }
            else
            {
                Debug.WriteLine("Film inexistant");
                return false;
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
                foreach (Film f in li)
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

        public void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
