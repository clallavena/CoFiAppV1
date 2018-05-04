using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// La classe Réalisateur est composé d'un nom, d'un prénom, d'une date de naissance, d'une date de mort (optionnel), d'une nationalité et d'une biographie
    /// </summary>
    public class Realisateur
    {
        /// <summary>
        /// Nom du réalisateur
        /// </summary>
        public string Nom
        {
            get; private set;
        }

        /// <summary>
        /// Prénom du réalisateur
        /// </summary>
        public string Prenom
        {
            get; private set;
        }

        /// <summary>
        /// Date de naissance de l'utilisateur
        /// </summary>
        public DateTime DateDeNaissance
        {
            get; private set;
        }

        /// <summary>
        /// Date de mort de l'utilisateur (optionnel)
        /// </summary>
        public DateTime? DateDeMort
        {
            get; private set;
        }

        /// <summary>
        /// Nationalité de l'utilisateur
        /// </summary>
        public string Nationalite
        {
            get; private set;
        }

        /// <summary>
        /// Biographie de l'utilisateur
        /// </summary>
        public string Biographie
        {
            get; private set;
        }

        /// <summary>
        /// Constructeur d'un réalisateur sans date de mort
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="nationalite"></param>
        /// <param name="biographie"></param>
        public Realisateur(string nom, string prenom, DateTime dateDeNaissance, string nationalite, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Nationalite = nationalite;
            Biographie = biographie;
            DateDeMort = null;
        }

        public Realisateur(string nom, string prenom, DateTime dateDeNaissance, DateTime dateDeMort, string nationalite, string biographie) : this(nom, prenom, dateDeNaissance, nationalite, biographie)
        {
            DateDeMort = dateDeMort;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Nom);
            sb.Append(" ");
            sb.Append(Prenom);
            sb.Append(" ");
            sb.Append(DateDeNaissance.ToShortDateString());

            if(DateDeMort.HasValue)            {
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
