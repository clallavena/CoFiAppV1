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
    public partial class FilmDesc : UserControl
    {
        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }
        public FilmDesc()
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
            DependencyProperty.Register("Titre", typeof(string), typeof(FilmDesc), new PropertyMetadata("sans titre"));


    }
}
