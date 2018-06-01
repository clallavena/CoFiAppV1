using CoFiAppV1.Frames;
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

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Dictionary<string, Func<UserControl>> Parts => (Application.Current as App).NavManager.Parts;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LeManager.FilmSelected != null)
            {
                NavManager.SelectedPart = NavManager.Parts["FilmDesc"]();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LeManager.Chargement();
            DataContext = this;
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }
    }
}
