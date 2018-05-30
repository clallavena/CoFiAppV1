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
    /// Logique d'interaction pour AccueilUC.xaml
    /// </summary>
    public partial class AccueilUC : UserControl
    {
        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public NavigationManager NavManager => (Application.Current as App).NavManager;
        public AccueilUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du Boutton "Admin"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            LogAdmin admin = new LogAdmin();
            admin.Show();
        }

        /// <summary>
        /// Evenement du boutton "Indépendant" amenant vers la page Indépendant de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inde_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Independant"]();
        }

        /// <summary>
        /// Evenement qui gère l'ajout et demande à l'utilisateur ce qu'il souhaite ajouter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (LeManager.CurrentUser != null)
            {
                MessageBox.Show("Test ok", "Test", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Il faut être administrateur!", "Permission non accordée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
    }
}
