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
    /// Logique d'interaction pour AddDirectorUC.xaml
    /// </summary>
    public partial class AddDirectorUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public AddDirectorUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void AddDirector_Click(object sender, RoutedEventArgs e)
        {
            String Nom;
            String Prenom;
            DateTime Naissance = new DateTime();
            DateTime Mort = new DateTime();
            String Nationalite;
            String Biographie;

            if (String.IsNullOrWhiteSpace(NomDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(PrenomDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(NationaliteDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(BiographieDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format", MessageBoxButton.OK);
                return;
            }

            Nom = NomDirector.Text;
            Prenom = PrenomDirector.Text;

            Nationalite = NationaliteDirector.Text;
            Biographie = BiographieDirector.Text;

            Personne directorToAdd = new Personne(Nom, Prenom, new DateTime(), Nationalite, Biographie);
            LeManager.AjouterReal(directorToAdd);
            MessageBox.Show("Vous avez ajouter le réalisateur " + directorToAdd.Nom + " " + directorToAdd.Prenom + " avec succès.", "Ajout réalisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }
    }
}
