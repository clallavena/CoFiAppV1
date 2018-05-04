using Metier;
using System;
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
            Acteur a = new Acteur("Tom", "Hanks");

            Admin admin = new Admin("esbarland", "azerty");

            List<Acteur> listActeurs = new List<Acteur>();
            listActeurs.Add(new Acteur("Paul", "Jean"));
            listActeurs.Add(new Acteur("Jack", "Pierre"));
            listActeurs.Add(new Acteur("Roger", "Robert"));
            Film f = new Film("Star Wars", 2017, "une histoire géniale", listActeurs, Tag.Science_Fiction, Tag.Aventure);


            Realisateur r = new Realisateur("Georges", "Lucas", new DateTime(1944, 05, 14), new DateTime(1968, 06, 08), "Américain", "super bonhomme");
            Realisateur ra = new Realisateur("Georges", "Paul", new DateTime(1988, 06, 08), "Américain", "petit garçon");

            Console.WriteLine(a);
            Console.WriteLine(admin);
            Console.WriteLine(f);
            Console.WriteLine(r);
            Console.WriteLine(ra);

            Acteur b = new Acteur("Tom", "Hanks");

            Console.WriteLine("\n" + (a == b) + " " + a.Equals(b) + " " + b.Equals(a));

        }
    }
}
