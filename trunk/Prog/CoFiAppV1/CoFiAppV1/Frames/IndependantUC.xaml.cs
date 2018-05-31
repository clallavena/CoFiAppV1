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


        List<Film> listInde = new List<Film>();

        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public IndependantUC()
        {
            InitializeComponent();
            DataContext = this;
            //A revoir la liste des films indépendants car ça ne marche pas
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
    }
}
