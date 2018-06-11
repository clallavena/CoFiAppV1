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
    /// Logique d'interaction pour IndependantUC.xaml
    /// </summary>
    public partial class IndependantUC : UserControl
    {

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }


        private List<Film> listInde = new List<Film>();

        public IEnumerable<Film> ListInde
        {
            get { return listInde; }
            private set { }
        }

        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public IndependantUC()
        {
            InitializeComponent();
            DataContext = this;
            foreach (Film f in LeManager.Films)
            {
                if (f.ListTags.Contains(Metier.Tag.Independant))
                {
                    listInde.Add(f);
                }
            }
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void Vignette_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["FilmDesc"]();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous ajouter un Réalisateur ?", "Ajouter Réal", MessageBoxButton.YesNoCancel);

            if (result.ToString().Equals("Yes"))
            {
                NavManager.SelectedPart = NavManager.Parts["AddDirector"]();
            }
            else if (result.ToString().Equals("No"))
            {
                MessageBoxResult result2 = MessageBox.Show("Voulez-vous ajouter un Film ?", "Ajouter Film", MessageBoxButton.YesNoCancel);

                if (result2.ToString().Equals("Yes"))
                {
                    NavManager.SelectedPart = NavManager.Parts["AddFilm"]();
                }
            }
        }

    }
}
