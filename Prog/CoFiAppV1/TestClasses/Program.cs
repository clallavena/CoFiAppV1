using Metier;
using Metier.DataManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataManager dm = new StubDataManager();

            Manager m = new Manager(dm)
            {
                Films = (List<Film>)dm.ChargementFilms()
            };


            //Dictionary de personnes pour test film1
            Dictionary<Job, List<Personne>> personnes = new Dictionary<Job, List<Personne>>();
            List<Personne> acteurs = new List<Personne>
            {
                new Personne("jack", "paul"),
                new Personne("anne", "champetre")
            };
            List<Personne> reals = new List<Personne>
            {
                new Personne("Lucas", "george"),
                new Personne("Durif", "sylvain")
            };

            personnes.Add(Job.Acteur, acteurs);
            personnes.Add(Job.Realisateur, reals);

            ////Dictionary de personnes pour test film22
            //Dictionary<Job, List<Personne>> perso2 = new Dictionary<Job, List<Personne>>();
            //List<Personne> acteurs2 = new List<Personne>
            //{
            //    new Personne("pierre", "truffaux"),
            //    new Personne("lise", "dutroux")
            //};
            //List<Personne> reals2 = new List<Personne>
            //{
            //    new Personne("Zemeckis", "Robert"),
            //};

            //perso2.Add(Job.Acteur, acteurs2);
            //perso2.Add(Job.Realisateur, reals2);

            Film f = new Film("Star Wars", 1990, "superbe histoire", personnes, Tag.Action, Tag.Aventure);

            //Film f1 = new Film("Star Wars", 1990, "superbe histoire", personnes, Tag.Action, Tag.Aventure);

            //Film f2 = new Film("Forrest Gump", 1994, "superbe histoire", perso2, Tag.Drame, Tag.Comedie_Dramatique);

            m.AjouterFilm(f);
            //m.AjouterFilm(f1);
            //m.AjouterFilm(f2);

            Console.WriteLine(f);



            //Test de la recherche
            IEnumerable<Film> fl = m.RechercherReal("Lucas", "george");

            //foreach (Film fi in fl)
            //{
            //    Console.WriteLine(fi.Titre);
            //}
            
            ////Test ajout de Film
            //foreach (Film fi in m.Films)
            //{
            //    Console.WriteLine(fi);
            //}

            //Console.WriteLine("/////////////////////////////////////////////");

            //m.AjouterFilm(f);

            //foreach (Film fi in m.Films)
            //{
            //    Console.WriteLine(fi);
            //}

            //Console.WriteLine("/////////////////////////////////////////////");

            //m.AjouterFilm(f2);

            //foreach (Film fi in m.Films)
            //{
            //    Console.WriteLine(fi);
            //}

            //Console.WriteLine("/////////////////////////////////////////////");

            //m.AjouterFilm(f1);

            //foreach (Film fi in m.Films)
            //{
            //    Console.WriteLine(fi);
            //}

            //Console.WriteLine("/////////////////////////////////////////////");

        }
    }
}
