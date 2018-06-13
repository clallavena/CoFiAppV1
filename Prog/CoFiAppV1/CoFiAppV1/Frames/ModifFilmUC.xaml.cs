using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Logique d'interaction pour ModifFilmUC.xaml
    /// </summary>
    public partial class ModifFilmUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

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

        private ObservableCollection<Personne> lpa = new ObservableCollection<Personne>();

        public ObservableCollection<Personne> Lpa
        {
            get { return lpa; }
            set { }
        }

        private ObservableCollection<Personne> lpr = new ObservableCollection<Personne>();

        public ObservableCollection<Personne> Lpr
        {
            get { return lpr; }
            set { }
        }

        private List<Personne> lpaList = new List<Personne>();

        private List<Personne> lprList = new List<Personne>();

        private String SourcePath;

        public ModifFilmUC()
        {
            InitializeComponent();
            DataContext = this;
            ChargementListes();
        }

        /// <summary>
        /// Charger les listes des acteurs et des réalisateurs du film
        /// </summary>
        private void ChargementListes()
        {
            lprList = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Realisateur).SelectMany(s => s.Value).ToList();
            foreach (Personne p in lprList)
            {
                lpr.Add(p);
            }
            lpaList = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Acteur).SelectMany(s => s.Value).ToList();
            foreach (Personne p in lpaList)
            {
                lpa.Add(p);
            }
        }

        /// <summary>
        /// Retourner à l'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.FilmSelected = null;
        }

        /// <summary>
        /// Supprimer un tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTag_Click(object sender, RoutedEventArgs e)
        {
            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (listTags.SelectedItem == null)
            {
                MessageBox.Show("Le tag sélectionné n'est pas valide", "Erreur suppression", MessageBoxButton.OK);
                return;
            }
            string tagToDelete = listTags.SelectedItem.ToString();

            foreach (Tag t in LeManager.FilmSelected.ListTags)
            {
                if (t.ToString() == tagToDelete)
                {
                    LeManager.FilmSelected.ListTags.Remove(t);
                    MessageBox.Show("Vous avez supprimé le tag " + tagToDelete + " avec succès", "Suppression de tag", MessageBoxButton.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// Ajouter un tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (listAllTags.SelectedItem == null)
            {
                MessageBox.Show("Le tag sélectionné n'est pas valide", "Erreur ajout", MessageBoxButton.OK);
                return;
            }

            Tag tagToAdd = (Tag)Enum.Parse(typeof(Tag), listAllTags.SelectedItem.ToString());
            if (LeManager.FilmSelected.ListTags.Contains(tagToAdd)) return;

            LeManager.FilmSelected.ListTags.Add(tagToAdd);
            listAllTags.SelectedIndex = -1;
            MessageBox.Show("Vous avez ajouté le tag " + tagToAdd + " avec succès", "Ajout de tag", MessageBoxButton.OK);
        }

        /// <summary>
        /// Supprimer un acteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteActor_Click(object sender, RoutedEventArgs e)
        {

            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (listActors.SelectedIndex == -1)
            {
                MessageBox.Show("L'acteur sélectionné n'est pas valide", "Erreur suppression", MessageBoxButton.OK);
                return;
            }
            string actorToDelete = listActors.SelectedItem.ToString();

            foreach (Personne p in lpa)
            {
                if (listActors.Text.Contains(p.Nom) && listActors.Text.Contains(p.Prenom))
                {
                    Personne buff = new Personne(p);
                    lpa.Remove(buff);
                    LeManager.FilmSelected.Personnes.Remove(Job.Acteur);
                    LeManager.FilmSelected.Personnes.Add(Job.Acteur, lpa.ToList());
                    MessageBox.Show("Vous avez supprimé l'acteur " + buff.Nom + " " + buff.Prenom + " avec succès", "Suppression d'acteur", MessageBoxButton.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// Ajouter un acteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddActor_Click(object sender, RoutedEventArgs e)
        {

            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(NomActor.Text) || String.IsNullOrWhiteSpace(PrenomActor.Text))
            {
                MessageBox.Show("Les champs Nom et Prénom sont vides ou mal renseignés", "Erreur ajout", MessageBoxButton.OK);
                return;
            }

            Personne personneToAdd = new Personne(NomActor.Text, PrenomActor.Text);

            foreach (Personne p in lpa)
            {
                if (p.Equals(personneToAdd))
                {
                    MessageBox.Show("Cet acteur est déjà existant", "Erreur ajout", MessageBoxButton.OK);
                    return;
                }
            }

            NomActor.Clear();
            PrenomActor.Clear();
            lpa.Add(personneToAdd);
            LeManager.FilmSelected.Personnes.Remove(Job.Acteur);
            LeManager.FilmSelected.Personnes.Add(Job.Acteur, lpa.ToList());
            MessageBox.Show("Vous avez ajouté l'acteur " + personneToAdd.Nom + " " + personneToAdd.Prenom + " avec succès", "Ajout d'acteur", MessageBoxButton.OK);

        }

        /// <summary>
        /// Supprimer un réalisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDirector_Click(object sender, RoutedEventArgs e)
        {
            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (listDirector.SelectedIndex == -1)
            {
                MessageBox.Show("Le réalisateur sélectionné n'est pas valide", "Erreur suppression", MessageBoxButton.OK);
                return;
            }
            string directorToDelete = listDirector.SelectedItem.ToString();

            foreach (Personne p in lpr)
            {
                if (listDirector.Text.Contains(p.Nom) && listDirector.Text.Contains(p.Prenom))
                {
                    Personne buff = new Personne(p);
                    lpr.Remove(buff);
                    LeManager.FilmSelected.Personnes.Remove(Job.Realisateur);
                    LeManager.FilmSelected.Personnes.Add(Job.Realisateur, lpr.ToList());
                    MessageBox.Show("Vous avez supprimé le réalisateur " + buff.Nom + " " + buff.Prenom + " avec succès", "Suppression de réalisateur", MessageBoxButton.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// Ajouter un réalisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDirector_Click(object sender, RoutedEventArgs e)
        {

            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(listAllDirectors.Text))
            {
                MessageBox.Show("Le réalisateur sélectionné n'est pas valide", "Erreur ajout", MessageBoxButton.OK);
                return;
            }

            Personne directorToAdd = new Personne("", "");

            foreach (Personne p in LeManager.ListReal)
            {
                if (listAllDirectors.Text.Contains(p.Nom) && listAllDirectors.Text.Contains(p.Prenom))
                {
                    directorToAdd = new Personne(p);
                    break;
                }

            }

            foreach (Personne p in lpr)
            {
                if (p.Equals(directorToAdd))
                {
                    MessageBox.Show("Ce réalisateur est déjà existant", "Erreur ajout", MessageBoxButton.OK);
                    return;
                }
            }

            listAllDirectors.SelectedIndex = -1;
            lpr.Add(directorToAdd);
            LeManager.FilmSelected.Personnes.Remove(Job.Realisateur);
            LeManager.FilmSelected.Personnes.Add(Job.Realisateur, lpr.ToList());
            MessageBox.Show("Vous avez ajouté le réalisateur " + directorToAdd.Nom + " " + directorToAdd.Prenom + " avec succès", "Ajout de réalisateur", MessageBoxButton.OK);
        }

        /// <summary>
        /// Ouvrir le navigateur de fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileBrowser_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = "C:\\Users\\Public\\Desktop";
            dlg.DefaultExt = ".jpg | .png | .gif";
            dlg.Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif";

            if (!toggleButton.IsChecked.Value)
            {
                MessageBox.Show("Appuyez d'abord sur le bouton Modifier !", "Erreur modification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                SourcePath = dlg.FileName;
            }            
        }

        /// <summary>
        /// Lorsque le toggle button est décoché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            string extension;
            string pathimg;

            if (SourcePath != null)
            {
                int index = 0;

                for (; SourcePath[index] != '.'; ++index)
                { }

                extension = SourcePath.Remove(0, index);
                pathimg = $"{LeManager.FilmSelected.Titre.ToLower().Replace(" ", string.Empty)}{extension}";
                if (LeManager.FilmSelected.PathFile == pathimg && !LeManager.FilmSelected.PathFile.Contains("noavatar.png"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cofiapp\\trunk\\Prog\\CoFiAppV1\\CoFiAppV1\\img\\" +LeManager.FilmSelected.PathFile);
                }
                File.Move(SourcePath, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cofiapp\\trunk\\Prog\\CoFiAppV1\\CoFiAppV1\\img\\" + pathimg);
                LeManager.FilmSelected.PathFile = pathimg;
            }

            listAllDirectors.IsEnabled = false;
            listDirector.IsEnabled = false;
            listTags.IsEnabled = false;
            listAllTags.IsEnabled = false;
            listActors.IsEnabled = false;
        }

        /// <summary>
        /// Lorsque le toggle button est coché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            listAllDirectors.IsEnabled = true;
            listDirector.IsEnabled = true;
            listTags.IsEnabled = true;
            listAllTags.IsEnabled = true;
            listActors.IsEnabled = true;
        }
    }
}
