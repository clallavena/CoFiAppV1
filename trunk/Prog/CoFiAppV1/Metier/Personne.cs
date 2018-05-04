using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// La classe Personne comporte un nom et un prénom
    /// </summary>
    public class Personne
    {
        /// <summary>
        /// Nom de la personne
        /// </summary>
        public string Nom
        {
            get; private set;
        }

        /// <summary>
        /// Prénom de la personne
        /// </summary>
        public string Prenom
        {
            get; private set;
        }
    }
}
