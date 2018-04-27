using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRealisateur
{
    class Program
    {
        static void Main(string[] args)
        {
            Realisateur real = new Realisateur("Stanley", "Kubrick", DateTime.Now, DateTime.Now, "Américain", "il avait un gros nez");
            Console.WriteLine(real);
        }
    }
}
