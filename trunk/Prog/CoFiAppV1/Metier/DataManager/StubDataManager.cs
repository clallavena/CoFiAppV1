using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.DataManager
{
    public class StubDataManager : IDataManager
    {
        public IEnumerable<Admin> ChargementAdmin()
        {
            List<Admin> admins = new List<Admin>
            {
                new Admin("esbarland", "coucou"),
                new Admin("clallavena", "bigboss")
            };

            return admins;
        }

        public IEnumerable<Film> ChargementFilms()
        {

            List<Film> films = new List<Film>();

            //Film1
            Dictionary<Job, List<Personne>> filmForrest = new Dictionary<Job, List<Personne>>();
            List<Personne> listPA_f1 = new List<Personne>();
            List<Personne> listPR_f1 = new List<Personne>();

            listPA_f1.Add(new Personne("Hanks", "Tom"));
            listPA_f1.Add(new Personne("Sinise", "Gary"));
            listPA_f1.Add(new Personne("Wright", "Robin"));

            listPR_f1.Add(new Personne("Zemeckis", "Robert", new DateTime(1952, 05, 14), "Americain", "Fabuleux Réal"));
            listPR_f1.Add(new Personne("Lucas", "Georges", new DateTime(1852, 05, 14), "Americain", "Fabuleux Réal"));

            filmForrest.Add(Job.Acteur, listPA_f1);
            filmForrest.Add(Job.Realisateur, listPR_f1);

            //Film2
            Dictionary<Job, List<Personne>> filmInterstellar = new Dictionary<Job, List<Personne>>();
            List<Personne> listPA_f2 = new List<Personne>();
            List<Personne> listPR_f2 = new List<Personne>();

            listPA_f2.Add(new Personne("McConaughey", "Matthew"));
            listPA_f2.Add(new Personne("Hathaway", "Anne"));
            listPA_f2.Add(new Personne("Jessica", "Chastain"));

            listPR_f2.Add(new Personne("Nolan", "Christophe", new DateTime(1970, 07, 30), "Anglais", "XOXOXO"));

            filmInterstellar.Add(Job.Acteur, listPA_f2);
            filmInterstellar.Add(Job.Realisateur, listPR_f2);


            //Ajout de film à la liste
            Film forrest = new Film("Forrest Gump", 1994, "Film dramatique, racontant l'histoire d'un homme à travers l'histoire de l'amérique qui a plein de problèmes partout où il va. ", filmForrest, Tag.Drame, Tag.Comedie_Dramatique, Tag.Independant);
            films.Add(forrest);
            Film interstellar = new Film("Interstellar", 2014, "Film de science-fiction, racontant l'histoire d'explorateurs partis chercher une planète plus acceuillante à travers un voyage interstellaire.", filmInterstellar, Tag.Science_Fiction, Tag.Drame);
            films.Add(interstellar);


            return films;
        }


        /// <summary>
        /// Chargement d'une liste de réalisateur de base, retourne une liste de Réalisateur. //!! Solution provisoire !!\\
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Personne> ChargementReal()
        {
            ObservableCollection<Personne> reals = new ObservableCollection<Personne>();

            reals.Add(new Personne("Nolan", "Christophe", new DateTime(1970, 07, 30), "Anglais", "XOXOXO"));
            reals.Add(new Personne("Zemeckis", "Robert", new DateTime(1952, 05, 14), "Americain", "Fabuleux Réal"));
            reals.Add(new Personne("Lucas", "Georges", new DateTime(1852, 05, 14), "Americain", "Fabuleux Réal"));

            return reals;
        }

        public void SauvegardeFilms(IEnumerable<Film> films)
        {

        }
    }
}
