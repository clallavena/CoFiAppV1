using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Film
    {
        public string Titre
        {
            get; set;
        }

        public int DateDeSortie
        {
            get; set;
        }

        public List<Tag> ListTags
        {
            get; set;
        }

        public string Synopsis
        {
            get; set;
        }

        public Film(string titre, int dateDeSortie, string synopsis, params Tag[] listTags)        {
            ListTags = new List<Tag>();
            Titre = titre;
            DateDeSortie = dateDeSortie;
            Synopsis = synopsis;

            foreach(var e in listTags)
            {
                ListTags.Add(e);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Titre);
            sb.Append(" ");
            sb.Append(DateDeSortie);
            sb.Append(" ");
            sb.Append(Synopsis);


            foreach(var e in ListTags)
            {
                sb.Append(" ");
                sb.Append(e);
            }

            return sb.ToString();
        }
    }
}
