using Metier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoFiAppV1.Frames
{
    /// <summary>
    /// Logique d'interaction pour ModifFilmUC.xaml
    /// </summary>
    public partial class ModifFilmUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        private IEnumerable<String> listAllTag = Enum.GetValues(typeof(Metier.Tag)).Cast<Tag>().Select(s => s.ToString()).ToList();

        public IEnumerable<String> ListAllTag
        {
            get
            {
                return listAllTag;
            }
            set {}
        }

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        private List<Personne> lpr = new List<Personne>();

        public IEnumerable<Personne> Lpr
        {
            get { return lpr; }
            set { }
        }

        private List<Personne> lpa = new List<Personne>();

        public IEnumerable<Personne> Lpa
        {
            get { return lpa; }
            set { }
        }

        public ModifFilmUC()
        {
            InitializeComponent();
            DataContext = this;
            foreach (Film f in LeManager.Films)
            {
                lpr.AddRange(f.Personnes.Where(p => p.Key == Job.Realisateur).SelectMany(s => s.Value).ToList());
            }
            //lpr = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Realisateur).SelectMany(s => s.Value).ToList();
            lpa = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Acteur).SelectMany(s => s.Value).ToList();
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void DeleteTag_Click(object sender, RoutedEventArgs e)
        {
            if (listTags.SelectedItem == null) return;

            string tagToDelete = listTags.SelectedItem.ToString();

            foreach (Tag t in LeManager.FilmSelected.ListTags)
            {
                if (t.ToString() == tagToDelete)
                {
                    LeManager.FilmSelected.ListTags.Remove(t);
                    MessageBox.Show("Vous avez supprimé le tag " + tagToDelete + " avec succès", "Suppresion de tag", MessageBoxButton.OK);
                    return;
                }
            }
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            if (listAllTags.SelectedItem == null) return;
            
            Tag tagToAdd = (Tag)Enum.Parse(typeof(Tag), listAllTags.SelectedItem.ToString());
            if (LeManager.FilmSelected.ListTags.Contains(tagToAdd)) return;

            LeManager.FilmSelected.ListTags.Add(tagToAdd);
            MessageBox.Show("Vous avez ajouté le tag " + tagToAdd + " avec succès", "Ajout de tag", MessageBoxButton.OK);
        }

        private void DeleteActor_Click(object sender, RoutedEventArgs e)
        {
           /* if (listActors.SelectedItem == null) return;

            string actorToDelete = listActors.ToString();
            Debug.Write(actorToDelete);*/
        }
    }
}
