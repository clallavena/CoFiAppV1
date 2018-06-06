using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Personne> listeActeur = new ObservableCollection<Personne>();

        Dictionary<Job, List<Personne>> personnesAdd = new Dictionary<Job, List<Personne>>();

        public ObservableCollection<Personne> LiA
        {
            get
            {
                return listeActeur;
            }
            set { }
        } 

        private IEnumerable<String> listAllTag = Enum.GetValues(typeof(Metier.Tag)).Cast<Tag>().Select(s => s.ToString()).ToList();

        public IEnumerable<String> ListAllTag
        {
            get
            {
                return listAllTag;
            }
            set { }
        }

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
            Tag tag1 = new Tag();
            Tag tag2 = new Tag();
            Tag tag3 = new Tag();
            List<Tag> listTagFilm = new List<Tag>();

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
                    if (ComboReal.Text.Contains(p.Nom))
                    {
                        buff = new Personne(p);
                        li.Add(buff);
                        personnesAdd.Add(Job.Realisateur, li);
                        break;
                    }

                }


                tag1 = (Tag)Enum.Parse(typeof(Tag), listTags1.SelectedItem.ToString());

                if (listTags2.SelectedItem != null)
                {
                    tag2 = (Tag)Enum.Parse(typeof(Tag), listTags2.SelectedItem.ToString());
                }
                else
                {
                    Film f2 = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1);
                    LeManager.AjouterFilm(f2);
                    return;
                }

                if (listTags3.SelectedItem != null)
                {
                    tag3 = (Tag)Enum.Parse(typeof(Tag), listTags3.SelectedItem.ToString());
                }
                else
                {
                    Film f3 = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1, tag2);
                    LeManager.AjouterFilm(f3);
                    return;
                }


                personnesAdd.Add(Job.Acteur, LiA.ToList());
                Film f = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1, tag2, tag3);
                LeManager.AjouterFilm(f);
            }
            else
            {
                MessageBox.Show("Le titre n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
            }
        }

        private void DeleteActor_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AjouterActeur_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Nom_TextBox.Text) || string.IsNullOrWhiteSpace(Prenom_TextBox.Text))
            {
                MessageBox.Show("Nom + Prenom mal ou non renseigné", "Ajout Impossible", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            Personne pAdd = new Personne(Nom_TextBox.Text, Prenom_TextBox.Text);

            foreach(Personne p in LiA)
            {
                if (p.Equals(pAdd))
                {
                    MessageBox.Show("Acteur déjà existant", "Erreur Ajout Acteur", MessageBoxButton.OK);
                    return;
                }
            }

            LiA.Add(pAdd);
        }
    }
}
