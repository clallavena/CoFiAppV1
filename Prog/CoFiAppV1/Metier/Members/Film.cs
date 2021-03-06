﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Metier
{
    /// <summary>
    /// La classe Film est réprésenté par un titre, une date de sortie, une liste d'étiquettes, une chemin d'accés à l'image du film, un synopsis et une liste de personnes
    /// </summary>
    /// 
    [DataContract]
    public class Film : IEquatable<Film>, INotifyPropertyChanged
    {
        /// <summary>
        /// Titre du film
        /// </summary>

        [DataMember]
        public string Titre
        {
            get; set;
        }

        /// <summary>
        /// Date de sortie du film (année)
        /// </summary>
        [DataMember(Name = "Date De Sortie")]
        public int DateDeSortie
        {
            get; set;
        }

        /// <summary>
        /// Liste des étiquettes
        /// Cette liste comprend les différents types d'un film peur avoir (par exemple : action et aventure)
        /// </summary>
        /// 
        [DataMember(Name = "Tags")]
        public ObservableCollection<Tag> ListTags
        {
            get; set;
        }

        /// <summary>
        /// Synopsis du film
        /// </summary>
        /// 
        [DataMember]
        public string Synopsis
        {
            get; set;
        }

        /// <summary>
        /// Chemin d'accés à l'image
        /// </summary>
        private string pathfile;

        [DataMember]
        public string PathFile
        {
            get { return pathfile; }
            set { pathfile = value; OnNotifyPropertyChanged(nameof(PathFile)); }
        }

        /// <summary>
        /// Association des différentes personnes présentes pour la réalisation du film
        /// </summary> 
        /// 
        [DataMember]
        public Dictionary<Job, List<Personne>> Personnes
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructeur d'un film
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="dateDeSortie"></param>
        /// <param name="synopsis"></param>
        /// <param name="personnes"></param>
        /// <param name="listTags"></param>
        public Film(string titre, int dateDeSortie, string synopsis, Dictionary<Job, List<Personne>> personnes, ObservableCollection<Tag> listTags, string pathFile)
        {
            ListTags = new ObservableCollection<Tag>();
            Personnes = new Dictionary<Job, List<Personne>>();
            Titre = titre;
            DateDeSortie = dateDeSortie;
            Synopsis = synopsis;

            foreach (KeyValuePair<Job, List<Personne>> p in personnes)
            {
                Personnes.Add(p.Key, p.Value);
            }
            
            foreach (var e in listTags)
            {
                ListTags.Add(e);
            }
            this.pathfile = pathFile;
        }

        /// <summary>
        /// Redéfinition de la méthode Equals pour comparer deux films
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Film);
        }

        public bool Equals(Film film)
        {
            return (film.Titre == this.Titre && film.DateDeSortie == this.DateDeSortie);
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

            sb.Append(" Acteurs: ");
            foreach (var p in Personnes.Where(s => s.Key == Job.Acteur)
                                       .SelectMany(kvp => kvp.Value))
            {
                sb.Append(p);
                sb.Append(", ");
            }

            sb.Append(" Réalisateurs: ");
            foreach (var p in Personnes.Where(s => s.Key == Job.Realisateur)
                                       .SelectMany(kvp => kvp.Value))
            {
                sb.Append(p);
                sb.Append(", ");
            }


            foreach (var e in ListTags)
            {
                sb.Append(" ");
                sb.Append(e);
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }

        public void OnNotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
