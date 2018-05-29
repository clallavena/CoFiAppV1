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
    /// Logique d'interaction pour AccueilUC.xaml
    /// </summary>
    public partial class AccueilUC : UserControl
    {
        public AccueilUC()
        {
            InitializeComponent();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            LogAdmin admin = new LogAdmin();
            admin.Show();
        }

        public NavigationManager NavManager => (Application.Current as App).NavManager;


        private void Inde_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Independant"]();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //A modifier et à personnaliser! 
            MessageBox.Show("Que Voulez-vous ajoutez ? ", "Ajouter", MessageBoxButton.YesNoCancel);

            NavManager.SelectedPart = NavManager.Parts["AddFilm"]();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            //A MODIFIER
            MessageBox.Show("Que Voulez-vous ajoutez ? ", "Ajouter", MessageBoxButton.YesNoCancel);
        }
    }
}
