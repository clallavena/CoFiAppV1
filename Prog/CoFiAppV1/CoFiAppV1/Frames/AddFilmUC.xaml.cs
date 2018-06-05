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
    /// Logique d'interaction pour AddFilmUC.xaml
    /// </summary>
    public partial class AddFilmUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public AddFilmUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            string Titre;
            int Sortie;
            string Synopsis;
            Personne buff;
            List<Personne> li = new List<Personne>();
            Dictionary<Job, List<Personne>> personnesAdd = new Dictionary<Job, List<Personne>>();

            if (!string.IsNullOrEmpty(TitreBox.Text))
            {
                Titre = TitreBox.Text;

                try
                {
                   Sortie = Int32.Parse(DateDeSortieBox.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur Format Date de Sortie", MessageBoxButton.OK);
                    return;
                }

                Synopsis = SynopsisBox.Text;

                foreach (Personne p in LeManager.ListReal)
                {
                    if (p.Nom.Contains(ComboReal.Text))
                    {
                        buff = new Personne(p);
                        li.Add(buff);
                        personnesAdd.Add(Job.Realisateur, li);
                        return;
                    }

                }

                Film f = new Film(Titre, Sortie, Synopsis, personnesAdd, Metier.Tag.Action);
                LeManager.AjouterFilm(f);
            }
            else
            {
                MessageBox.Show("Le titre n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
            }
        }
    }
}
