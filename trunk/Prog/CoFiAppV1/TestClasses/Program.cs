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

            Admin super = new Admin("esbarland", "azerty");

            List<Acteur> listActeurs = new List<Acteur>();
            listActeurs.Add(new Acteur("Paul", "Jean"));
            listActeurs.Add(new Acteur("Jack", "Pierre"));
            listActeurs.Add(new Acteur("Roger", "Robert"));
            Film f = new Film("Star Wars", 2017, "une histoire géniale", listActeurs, Tag.Science_Fiction, Tag.Aventure);


            Realisateur r = new Realisateur("Georges", "Lucas", new DateTime(1944, 05, 14), DateTime.Now, "Américain", "super bonhomme");

            Console.WriteLine(a);
            Console.WriteLine(super);
            Console.WriteLine(f);
            Console.WriteLine(r);

        }
    }
}
