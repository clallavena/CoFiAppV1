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

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour BarreDeRecherche.xaml
    /// </summary>
    public partial class BarreDeRecherche : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }
        public BarreDeRecherche()
        {
            InitializeComponent();
        }

        private void SearchB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LeManager.RechercherFilm(searchB.Text, LeManager.Films);
            }
        }

        private void SearchB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchB.Text))
            {
                LeManager.RechercherFilm(searchB.Text, LeManager.Films);
                NavManager.SelectedPart = NavManager.Parts["Accueil"]();
                LeManager.FilmSelected = null;
            }

            if (searchB.Text == "")
            {
                searchB.Text = "Rechercher";
            }
        }

        public void Loupe_Click(object sender, RoutedEventArgs e)
        {
            LeManager.RechercherFilm(searchB.Text, LeManager.Films);
        }

        private void SearchB_GotFocus(object sender, RoutedEventArgs e)
        {
            searchB.Text = "";
        }
    }
}
