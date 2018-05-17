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

            Manager m = new Manager(dm);

            /*Dictionary<Job, List<Personne>> personnes = new Dictionary<Job, List<Personne>>();
            List<Personne> acteurs = new List<Personne>();
            acteurs.Add(new Personne("jack", "paul"));
            acteurs.Add(new Personne("anne", "champetre"));
            List<Personne> reals = new List<Personne>();
            reals.Add(new Personne("georges", "lucas"));
            reals.Add(new Personne("sylvain", "durif"));

            personnes.Add(Job.Acteur, acteurs);
            personnes.Add(Job.Realisateur, reals);

            Film f = new Film("Star Wars", 1990, "superbe histoire", personnes, Tag.Action, Tag.Aventure);

            Film f1 = new Film("Star Wars", 1990, "superbe histoire", personnes, Tag.Action, Tag.Aventure);

            Film f2 = new Film("Forrest Gump", 1994, "superbe histoire", personnes, Tag.Drame, Tag.Comedie_Dramatique);


            foreach (Film fi in m.Films)
            {
                Console.WriteLine(fi);
            }

            Console.WriteLine("/////////////////////////////////////////////");

            m.AjouterFilm(f);

            foreach (Film fi in m.Films)
            {
                Console.WriteLine(fi);
            }

            Console.WriteLine("/////////////////////////////////////////////");

            m.AjouterFilm(f2);

            foreach (Film fi in m.Films)
            {
                Console.WriteLine(fi);
            }

            Console.WriteLine("/////////////////////////////////////////////");

            m.AjouterFilm(f1);

            foreach (Film fi in m.Films)
            {
                Console.WriteLine(fi);
            }

            Console.WriteLine("/////////////////////////////////////////////");
            */
        }
    }
}
