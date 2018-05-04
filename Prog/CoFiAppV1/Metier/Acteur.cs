using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// La classe Acteur représente un acteur de cinéma comportant un nom et un prénom
    /// </summary>
    public class Acteur : IEquatable<Acteur>
    {

        /// <summary>
        /// Nom de l'acteur
        /// </summary>
        public string Nom
        {
            get; private set;
        }

        /// <summary>
        /// Prénom de l'acteur
        /// </summary>
        public string Prenom
        {
            get; private set;
        }

        /// <summary>
        /// Constructeur d'un acteur avec son nom et son prénom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        public Acteur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }
        
        /// <summary>
        /// Redéfinition de la méthode Equals pour comparer deux acteurs
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true ou false pour savoir si les deux acteurs sont différents ou non</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() == this.GetType()) return true;
            return this.Equals(obj);
        }
        public bool Equals(Acteur other)
        {
            return other.Nom == this.Nom && other.Prenom == this.Prenom;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString pour un meilleur affichage
        /// </summary>
        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}
