﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Realisateur
    {
        public string Nom
        {
            get; private set;
        }

        public string Prenom
        {
            get; private set;
        }

        public DateTime DateDeNaissance
        {
            get; private set;
        }

        public DateTime DateDeMort
        {
            get; private set;
        }

        public string Nationalite
        {
            get; private set;
        }

        public string Biographie
        {
            get; private set;
        }

        public Realisateur(string nom, string prenom, DateTime dateDeNaissance, DateTime dateDeMort, string nationalite, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            DateDeMort = dateDeMort;
            Nationalite = nationalite;
            Biographie = biographie;
        }

        public Realisateur(string nom, string prenom, DateTime dateDeNaissance, string nationalite, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Nationalite = nationalite;
            Biographie = biographie;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            int year = DateDeNaissance.Year;
            int month = DateDeNaissance.Month;
            int day = DateDeNaissance.Day;

            sb.Append(Nom);
            sb.Append(" ");
            sb.Append(Prenom);
            sb.Append(" ");
            sb.Append(DateDeNaissance.ToShortDateString());

            if(!DateDeMort.Equals(new DateTime(0001, 01, 01)))
            {
                sb.Append(" ");
                sb.Append(DateDeMort.ToShortDateString());
            }

            sb.Append(" ");
            sb.Append(Nationalite);
            sb.Append(" ");
            sb.Append(Biographie);

            return sb.ToString();
        }

    }
}
