using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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


        Dictionary<Job, List<Personne>> personnesAdd = new Dictionary<Job, List<Personne>>();


        private ObservableCollection<Personne> listeActeur = new ObservableCollection<Personne>();

        public ObservableCollection<Personne> LiA
        {
            get
            {
                return listeActeur;
            }
            set { }
        }

        private IEnumerable<String> listAllTag = Enum.GetValues(typeof(Metier.Tag)).Cast<Tag>().Select(s => s.ToString()).ToList();

        private string SourcePath;

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
            LeManager.FilmSelected = null;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            string Titre;
            int Sortie;
            string Synopsis;
            Personne buff;
            List<Personne> lir = new List<Personne>();
            Tag tag1 = new Tag();
            Tag tag2 = new Tag();
            Tag tag3 = new Tag();

            if (String.IsNullOrWhiteSpace(TitreBox.Text))
            {
                MessageBox.Show("Le titre n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(DateDeSortieBox.Text))
            {
                MessageBox.Show("La date de sortie n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(SynopsisBox.Text))
            {
                MessageBox.Show("Le synopsis n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
                return;
            }

            try
            {
                Sortie = Int32.Parse(DateDeSortieBox.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Erreur Format Date de Sortie", MessageBoxButton.OK);
                return;
            }

            Titre = TitreBox.Text;
            Synopsis = SynopsisBox.Text;

            foreach (Personne p in LeManager.ListReal)
            {
                if (ComboReal.Text.Contains(p.Nom))
                {
                    buff = new Personne(p);
                    lir.Add(buff);
                    personnesAdd.Add(Job.Realisateur, lir);
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
                int index = 0;

                for (; SourcePath[index] != '.'; ++index)
                {}
                
                string extension = SourcePath.Remove(0, index);
                string pathimg = $"\\..\\..\\img\\{Titre.ToLower().Replace(" ", string.Empty)}{extension}";

                personnesAdd.Add(Job.Acteur, listeActeur.ToList());
                File.Move(SourcePath, Directory.GetCurrentDirectory() + pathimg);
                Film f2 = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1);

                f2.PathFile = Directory.GetCurrentDirectory() + pathimg;

                LeManager.AjouterFilm(f2);
                return;
            }

            if (listTags3.SelectedItem != null)
            {
                tag3 = (Tag)Enum.Parse(typeof(Tag), listTags3.SelectedItem.ToString());
            }
            else
            {
                personnesAdd.Add(Job.Acteur, listeActeur.ToList());
                File.Move(SourcePath, $"../img/{Titre.ToLower().Replace(" ", string.Empty)}.jpg");
                Film f3 = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1, tag2);
                LeManager.AjouterFilm(f3);
                return;
            }

            File.Move(SourcePath, $"../img/{Titre.ToLower().Replace(" ", string.Empty)}.jpg");

            personnesAdd.Add(Job.Acteur, listeActeur.ToList());
            Film f = new Film(Titre, Sortie, Synopsis, personnesAdd, tag1, tag2, tag3);
            LeManager.AjouterFilm(f);


            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void DeleteActor_Click(object sender, RoutedEventArgs e)
        {
            if (listActors.SelectedIndex == -1)
            {
                MessageBox.Show("L'acteur sélectionné n'est pas valide", "Erreur suppression", MessageBoxButton.OK);
                return;
            }
            string actorToDelete = listActors.SelectedItem.ToString();

            foreach (Personne p in listeActeur)
            {
                if (listActors.Text.Contains(p.Nom) && listActors.Text.Contains(p.Prenom))
                {
                    Personne buff = new Personne(p);
                    listeActeur.Remove(buff);
                    MessageBox.Show("Vous avez supprimé l'acteur " + buff.Nom + " " + buff.Prenom + " avec succès", "Suppression d'acteur", MessageBoxButton.OK);
                    return;
                }
            }
        }

        private void AjouterActeur_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nom_TextBox.Text) || string.IsNullOrWhiteSpace(Prenom_TextBox.Text))
            {
                MessageBox.Show("Nom + Prenom mal ou non renseigné", "Ajout Impossible", MessageBoxButton.OK);
                return;
            }

            Personne pAdd = new Personne(Nom_TextBox.Text, Prenom_TextBox.Text);

            foreach (Personne p in listeActeur)
            {
                if (p.Equals(pAdd))
                {
                    MessageBox.Show("Acteur déjà existant", "Erreur Ajout Acteur", MessageBoxButton.OK);
                    return;
                }
            }

            listeActeur.Add(pAdd);
            Nom_TextBox.Clear();
            Prenom_TextBox.Clear();
            MessageBox.Show("Vous avez ajouté l'acteur " + pAdd.Nom + " " + pAdd.Prenom + " avec succès", "Ajout d'acteur", MessageBoxButton.OK);
        }
        
        private void OpenFileBrowser_Click(object sender, RoutedEventArgs e)
        {
            //A voir comment faire en sorte que ça nous soit utile
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = "C:\\Users\\Public\\Desktop";
            dlg.DefaultExt = ".jpg | .png | .gif";
            dlg.Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif";
            
            bool? result = dlg.ShowDialog();
            
            if (result == true)
            {
                SourcePath = dlg.FileName;
            }
        }

    }
}
