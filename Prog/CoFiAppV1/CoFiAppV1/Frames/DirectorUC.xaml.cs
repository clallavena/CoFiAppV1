using Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour DirectorUC.xaml
    /// </summary>
    public partial class DirectorUC : UserControl, INotifyPropertyChanged
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public DirectorUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Signalement(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous signaler ce réalisateur ?", "Signalement", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result.ToString().Equals("Yes"))
            {
                try
                {
                    LeManager.Signaler(LeManager.RealSelected);
                    MessageBox.Show("le signalement a été effectué avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("le signalement n'a pas pu être envoyé, veuillez contacter un administrateur ! \n" + ex.ToString());
                }
            }
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.FilmSelected = null;
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (LeManager.CurrentUser != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez vous supprimez ce réalisateur ?", "Supprimer", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result.ToString().Equals("Yes"))
                {
                    if (LeManager.SupprimerReal(LeManager.RealSelected)) MessageBox.Show("Suppression effectué avec succés", "Suppression", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    else MessageBox.Show("Erreur lors de la suppression", "Suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                NotifyPropertyChanged("LeManager.ListReal");
                NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            }
            else
            {
                MessageBox.Show("Il faut être administrateur!", "Permission non accordée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
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

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["ModifReal"]();
        }
    }
}
