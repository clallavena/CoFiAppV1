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
    /// Logique d'interaction pour ModifRealUC.xaml
    /// </summary>
    public partial class ModifRealUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public List<int> Jours { get; set; }
        public List<int> Mois { get; set; }

        public int NaissanceJour { get; set; }
        public int NaissanceMois { get; set; }
        public int NaissanceAnnee { get; set; }
        public int MortJour { get; set; }
        public int MortMois { get; set; }
        public int MortAnnee { get; set; }

        public ModifRealUC()
        {
            InitializeComponent();
            InitDate();
            DataContext = this;
        }

        private void InitDate()
        {
            Jours = new List<int>();
            Mois = new List<int>();
            for (int i = 1; i < 32; i++)
            {
                Jours.Add(i);
            }
            for (int i = 1; i < 13; i++)
            {
                Mois.Add(i);
            }

            NaissanceJour = LeManager.RealSelected.DateDeNaissance.Day;
            NaissanceMois = LeManager.RealSelected.DateDeNaissance.Month;
            NaissanceAnnee = LeManager.RealSelected.DateDeNaissance.Year;
            if (LeManager.RealSelected.DateDeMort != null)
            {
                MortJour = LeManager.RealSelected.DateDeMort.Value.Day;
                MortMois = LeManager.RealSelected.DateDeMort.Value.Month;
                MortAnnee = LeManager.RealSelected.DateDeMort.Value.Year;
            }

        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.FilmSelected = null;
        }

        private void ModifReal_Unloaded(object sender, RoutedEventArgs e)
        {
            DateTime nais = new DateTime(NaissanceAnnee, NaissanceMois, NaissanceJour);
            DateTime? mort = new DateTime(MortAnnee, MortMois, MortJour);

            if (LeManager.RealSelected.DateDeNaissance != nais)
            {
                LeManager.RealSelected.DateDeNaissance = nais;
            }

            if (LeManager.RealSelected.DateDeMort != mort)
            {
                LeManager.RealSelected.DateDeMort = mort;
            }

        }
    }
}
