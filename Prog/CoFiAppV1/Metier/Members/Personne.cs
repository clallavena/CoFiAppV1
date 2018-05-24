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

        /// <summary>
        /// Date de naissance de la personne
        /// </summary>
        public DateTime DateDeNaissance
        {
            get; private set;
        }

        /// <summary>
        /// Date de mort de la personne (optionnel)
        /// </summary>
        public DateTime? DateDeMort
        {
            get; private set;
        }

        /// <summary>
        /// Nationalité de la personne
        /// </summary>
        public string Nationalite
        {
            get; private set;
        }

        /// <summary>
        /// Biographie de la personne
        /// </summary>
        public string Biographie
        {
            get; private set;
        }

        /// <summary>
        /// Constructeur avec un nom et un prénom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        public Personne(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        /// <summary>
        /// Constructeur avec un nom, un prénom, une date de naissance, une nationalité et une biographie
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="nationalite"></param>
        /// <param name="biographie"></param>
        public Personne(string nom, string prenom, DateTime dateDeNaissance, string nationalite, string biographie) : this(nom, prenom)
        {
            DateDeNaissance = dateDeNaissance;
            Nationalite = nationalite;
            Biographie = biographie;
            DateDeMort = null;
        }

        /// <summary>
        /// Constructeur avec un nom, un prénom, une date de naissance, une date de mort, une nationalité et une biographie
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="dateDeMort"></param>
        /// <param name="nationalite"></param>
        /// <param name="biographie"></param>
        public Personne(string nom, string prenom, DateTime dateDeNaissance, DateTime dateDeMort, string nationalite, string biographie) : this(nom, prenom, dateDeNaissance, nationalite, biographie)
        {
            DateDeMort = dateDeMort;
        }

        /// <summary>
        /// Redéfinition de la méthode Equals pour comparer deux personnes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true ou false pour savoir si les deux personnes sont différentes ou non</returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Personne);
        }

        public bool Equals(Personne other)
        {
            return other.Nom == this.Nom && other.Prenom == this.Prenom;
        }

        /// <summary>
        /// Redéfinition de ma méthode ToString
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Nationalite == null && Biographie == null)
            {
                sb.Append(Nom);
                sb.Append(" ");
                sb.Append(Prenom);
                sb.Append(" ");

                return sb.ToString();
            }

            sb.Append(Nom);
            sb.Append(" ");
            sb.Append(Prenom);
            sb.Append(" ");
            sb.Append(DateDeNaissance.ToShortDateString());

            if (DateDeMort.HasValue)
            {
                sb.Append(" ");
                sb.Append(DateDeMort.Value.ToShortDateString());
            }

            sb.Append(" ");
            sb.Append(Nationalite);
            sb.Append(" ");
            sb.Append(Biographie);

            return sb.ToString();
        }
    }
}
