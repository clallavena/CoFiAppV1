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
    /// Logique d'interaction pour FilmDesc.xaml
    /// </summary>
    public partial class FilmDescUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }
        public FilmDescUC()
        {
            InitializeComponent();
            DataContext = LeManager;
        }
        
        public string Titre
        {
            get { return (string)GetValue(TitreProperty); }
            set { SetValue(TitreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitreProperty =
            DependencyProperty.Register("Titre", typeof(string), typeof(FilmDescUC), new PropertyMetadata("sans titre"));

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void Signalement(object sender, RoutedEventArgs e)
        {
            try
            {
                LeManager.Signaler(LeManager.FilmSelected);
                MessageBox.Show("le signalement a été effectué avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("le signalement n'a pas pu être envoyé, veuillez contacter un administrateur ! \n" + ex.ToString());
            }            
        }
    }
}
