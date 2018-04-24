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

        public List<String> ListTags
        {
            get; set;
        }

        public string Synopsis
        {
            get; set;
        }

        public Film(string titre, int dateDeSortie, List<string> listTags,string synopsis)
        {
            Titre = titre;
            DateDeSortie = dateDeSortie;
            ListTags = listTags;
            Synopsis = synopsis;
        }

        public override string ToString()
        {
            return $"{Titre} {DateDeSortie} {ListTags} {Synopsis}";
        }
    }
}
