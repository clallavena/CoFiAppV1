using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// La classe Film est réprésenté par un titre, une date de sortie, une liste d'étiquettes, un synonpsis et une liste d'acteurs
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Titre du film
        /// </summary>
        public string Titre
        {
            get; private set;
        }

        /// <summary>
        /// Date de sortie du film (année)
        /// </summary>
        public int DateDeSortie
        {
            get; private set;
        }

        /// <summary>
        /// Liste des étiquettes
        /// Cette liste comprend les différents types d'un film peur avoir (par exemple : action et aventure)
        /// </summary>
        public List<Tag> ListTags
        {
            get; private set;
        }

        /// <summary>
        /// Synonpsis du film
        /// </summary>
        public string Synopsis
        {
            get; private set;
        }

        /// <summary>
        /// Liste des principaux acteurs présents dans le film
        /// </summary>
        public List<Acteur> ListActeurs
        {
            get; private set;
        }

        /// <summary>
        /// Constructeur d'un film
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="dateDeSortie"></param>
        /// <param name="synopsis"></param>
        /// <param name="listActeurs"></param>
        /// <param name="listTags"></param>
        public Film(string titre, int dateDeSortie, string synopsis, List<Acteur> listActeurs, params Tag[] listTags)        {
            ListTags = new List<Tag>();
            ListActeurs = new List<Acteur>();
            Titre = titre;
            DateDeSortie = dateDeSortie;
            Synopsis = synopsis;
            ListActeurs = listActeurs;

            foreach(var e in listTags)
            {
                ListTags.Add(e);
            }
        }

        /// <summary>
        /// Redéfinition de la méthode ToString pour un meilleur affichage
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Titre);
            sb.Append(" ");
            sb.Append(DateDeSortie);
            sb.Append(" ");
            sb.Append(Synopsis);

            foreach (var e in ListActeurs)
            {
                sb.Append(" ");
                sb.Append(e);
            }


            foreach(var e in ListTags)
            {
                sb.Append(" ");
                sb.Append(e);
            }

            return sb.ToString();
        }
    }
}
