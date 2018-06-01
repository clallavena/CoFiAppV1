using Metier;
using System;
using System.Collections.Generic;
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
    }
}
