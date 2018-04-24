using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestActeur
{
    class Program
    {
        static void Main(string[] args)
        {
            Acteur a = new Acteur("Nicholson", "Jack");
            Console.WriteLine($"{a}");
        }
    }
}
