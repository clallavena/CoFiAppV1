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

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.FilmSelected = null;
        }

        private void DeleteTag_Click(object sender, RoutedEventArgs e)
        {
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

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
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

        private void DeleteActor_Click(object sender, RoutedEventArgs e)
        {
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

        private void AddActor_Click(object sender, RoutedEventArgs e)
        {
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

        private void DeleteDirector_Click(object sender, RoutedEventArgs e)
        {
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

        private void AddDirector_Click(object sender, RoutedEventArgs e)
        {
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

        private void ModifFilm_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            string extension;
            string pathimg;

            if (SourcePath != null)
            {
                int index = 0;

                for (; SourcePath[index] != '.'; ++index)
                { }

                extension = SourcePath.Remove(0, index);
                pathimg = $"\\..\\..\\img\\{LeManager.FilmSelected.Titre.ToLower().Replace(" ", string.Empty)}{extension}";
                File.Move(SourcePath, Directory.GetCurrentDirectory() + pathimg);
                LeManager.FilmSelected.PathFile = Directory.GetCurrentDirectory() + pathimg;
            }
        }
    }
}
