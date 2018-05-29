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
        public BarreDeRecherche()
        {
            InitializeComponent();
        }

        private void SearchB_KeyDown(object sender, KeyEventArgs e)
        {
            if (searchB.Text == "Rechercher")
            {
                searchB.Text = "";
            }
        }

        private void SearchB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchB.Text == "")
            {
                searchB.Text = "Rechercher";
            }
        }
    }
}
