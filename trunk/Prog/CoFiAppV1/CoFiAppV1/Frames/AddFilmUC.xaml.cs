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
    /// Logique d'interaction pour AddFilmUC.xaml
    /// </summary>
    public partial class AddFilmUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public AddFilmUC()
        {
            InitializeComponent();
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }
    }
}
