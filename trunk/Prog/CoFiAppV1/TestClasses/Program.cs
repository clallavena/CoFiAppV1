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

            Film f = new Film("Star Wars", 2017, "une histoire géniale", Tag.Science_Fiction, Tag.Aventure);

            Realisateur r = new Realisateur("Georges", "Lucas", DateTime.FromOADate(30.02), DateTime.Now, "Américain", "super bonhomme");

            Console.WriteLine(a);
            Console.WriteLine(super);
            Console.WriteLine(f);
            Console.WriteLine(r);

        }
    }
}
