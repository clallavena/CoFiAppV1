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

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Vignette : UserControl
    {
        public Manager LeManager => (Application.Current as App).LeManager;

        public Vignette()
        {
            InitializeComponent();
        }

        public string PTitre
        {
            get { return (string)GetValue(PTitreProperty); }
            set { SetValue(PTitreProperty, value); }
        }       

        public string PImage
        {
            get { return (string)GetValue(PImageProperty); }
            set { SetValue(PImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PImageProperty =
            DependencyProperty.Register("PImage", typeof(string), typeof(Vignette), new PropertyMetadata("Shining.jpg"));



        // Using a DependencyProperty as the backing store for PTitre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PTitreProperty =
            DependencyProperty.Register("PTitre", typeof(string), typeof(Vignette), new PropertyMetadata("Sans nom"));
        
    }
}
