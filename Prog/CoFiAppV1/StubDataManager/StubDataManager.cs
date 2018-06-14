using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.DataManager
{
    public class StubDataManager : IDataManager
    {
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

            listPR_f1.Add(new Personne("Zemeckis", "Robert", new DateTime(1952, 05, 14), "Americain", "Fabuleux Réal", null));
            listPR_f1.Add(new Personne("Lucas", "Georges", new DateTime(1852, 05, 14), new DateTime(1930, 11, 9), "Americain", "Fabuleux Réal", null));

            filmForrest.Add(Job.Acteur, listPA_f1);
            filmForrest.Add(Job.Realisateur, listPR_f1);

            //Film2
            Dictionary<Job, List<Personne>> filmInterstellar = new Dictionary<Job, List<Personne>>();
            List<Personne> listPA_f2 = new List<Personne>();
            List<Personne> listPR_f2 = new List<Personne>();

            listPA_f2.Add(new Personne("McConaughey", "Matthew"));
            listPA_f2.Add(new Personne("Hathaway", "Anne"));
            listPA_f2.Add(new Personne("Jessica", "Chastain"));

            listPR_f2.Add(new Personne("Nolan", "Christophe", new DateTime(1970, 07, 30), "Anglais", "XOXOXO", null));

            filmInterstellar.Add(Job.Acteur, listPA_f2);
            filmInterstellar.Add(Job.Realisateur, listPR_f2);

            ObservableCollection<Tag> listTagsF = new ObservableCollection<Tag>();
            listTagsF.Add(Tag.Drame);
            listTagsF.Add(Tag.Comedie_Dramatique);
            listTagsF.Add(Tag.Independant);

            ObservableCollection<Tag> listTagsI = new ObservableCollection<Tag>();
            listTagsI.Add(Tag.Science_Fiction);
            listTagsI.Add(Tag.Drame);

            //Ajout de film à la liste
            Film forrest = new Film("Forrest Gump", 1994, "Film dramatique, racontant l'histoire d'un homme à travers l'histoire de l'amérique qui a plein de problèmes partout où il va. ", filmForrest, listTagsF, Directory.GetCurrentDirectory() + "forrest.jpg");
            forrest.PathFile = "/../../img/forrestgump.jpg";

            films.Add(forrest);

            Film interstellar = new Film("Interstellar", 2014, "Film de science-fiction, racontant l'histoire d'explorateurs partis chercher une planète plus acceuillante à travers un voyage interstellaire.", filmInterstellar, listTagsI, Directory.GetCurrentDirectory() + "interstellar.jpg");
            interstellar.PathFile = "/../../img/interstellar.jpg";
            films.Add(interstellar);


            return films;
        }

        public void SauvegardeFilms(IEnumerable<Film> films)
        {

        }

        /// <summary>
        /// Chargement d'une liste de réalisateur de base, retourne une liste de Réalisateur. //!! Solution provisoire !!\\
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Personne> ChargementReal()
        {
            ObservableCollection<Personne> reals = new ObservableCollection<Personne>();

            reals.Add(new Personne("Nolan", "Christophe", new DateTime(1970, 07, 30), "Anglais", "XOXOXO", null));
            reals.Add(new Personne("Zemeckis", "Robert", new DateTime(1952, 05, 14), "Americain", "Fabuleux Réal", null));
            reals.Add(new Personne("Lucas", "Georges", new DateTime(1852, 05, 14), "Americain", "Fabuleux Réal", null));

            return reals;
        }

        public void SauvegardeReal(ObservableCollection<Personne> personnes)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<Admin> ChargementAdmin()
        {
            List<Admin> admins = new List<Admin>
            {
                new Admin("esbarland", "coucou"),
                new Admin("clallavena", "bigboss")
            };

            return admins;
        }
    }
}
