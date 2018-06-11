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

        private ObservableCollection<Tag> listTagsFilm = new ObservableCollection<Tag>();

        public IEnumerable<Tag> ListTagsFilm
        {
            get
            {
                return listTagsFilm;
            }
            set
            {

            }
        }

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
            if (String.IsNullOrWhiteSpace(ComboReal.Text))
            {
                MessageBox.Show("Le réalisateur n'a pas été renseigné", "Erreur Ajout", MessageBoxButton.OK);
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

            string extension;
            string pathimg;

            if (SourcePath != null)
            {
                int index = 0;

                for (; SourcePath[index] != '.'; ++index)
                { }

                extension = SourcePath.Remove(0, index);
                pathimg = $"\\..\\..\\img\\{Titre.ToLower().Replace(" ", string.Empty)}{extension}";
                File.Move(SourcePath, Directory.GetCurrentDirectory() + pathimg);
            }
            else
            {
                pathimg = "\\..\\..\\img\\noavatar.png";
            }

            personnesAdd.Add(Job.Acteur, listeActeur.ToList());
            Film f = new Film(Titre, Sortie, Synopsis, personnesAdd, listTagsFilm, Directory.GetCurrentDirectory() + pathimg);

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

        private void SupprimerTag_Click(object sender, RoutedEventArgs e)
        {
            if (listTags.SelectedItem == null)
            {
                MessageBox.Show("Le tag sélectionné n'est pas valide", "Erreur suppression", MessageBoxButton.OK);
                return;
            }
            string tagToDelete = listTags.SelectedItem.ToString();

            foreach (Tag t in listTagsFilm)
            {
                if (t.ToString() == tagToDelete)
                {
                    listTagsFilm.Remove(t);
                    MessageBox.Show("Vous avez supprimé le tag " + tagToDelete + " avec succès", "Suppression de tag", MessageBoxButton.OK);
                    return;
                }
            }
        }

        private void AjouterTag_Click(object sender, RoutedEventArgs e)
        {
            if (listAllTags.SelectedItem == null)
            {
                MessageBox.Show("Le tag sélectionné n'est pas valide", "Erreur ajout", MessageBoxButton.OK);
                return;
            }

            Tag tagToAdd = (Tag)Enum.Parse(typeof(Tag), listAllTags.SelectedItem.ToString());
            if (listTagsFilm.Contains(tagToAdd)) return;

            listTagsFilm.Add(tagToAdd);
            listAllTags.SelectedIndex = -1;
            MessageBox.Show("Vous avez ajouté le tag " + tagToAdd + " avec succès", "Ajout de tag", MessageBoxButton.OK);
        }
    }
}
