using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Acteur
    {

        public string Nom
        {
            get; set;
        }

        public string Prenom
        {
            get; set;
        }

        public Acteur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Prenom: {Prenom}";
        }
        
    }
}
