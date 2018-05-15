using Metier;
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
            Dictionary<Job, List<Personne>> personnes = new Dictionary<Job, List<Personne>>();
            List<Personne> acteurs = new List<Personne>();
            acteurs.Add(new Personne("jack", "paul"));
            acteurs.Add(new Personne("anne", "champetre"));
            List<Personne> reals = new List<Personne>();
            reals.Add(new Personne("georges", "lucas"));
            reals.Add(new Personne("sylvain", "durif"));

            personnes.Add(Job.Acteur, acteurs);
            personnes.Add(Job.Realisateur, reals);

            Film f = new Film("Star Wars", 1990, "superbe histoire", personnes, Tag.Action, Tag.Aventure);
            Console.WriteLine(f);
            

        }
    }
}
