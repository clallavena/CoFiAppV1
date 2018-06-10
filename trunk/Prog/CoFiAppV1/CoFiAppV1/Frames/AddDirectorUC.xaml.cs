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
    /// Logique d'interaction pour AddDirectorUC.xaml
    /// </summary>
    public partial class AddDirectorUC : UserControl
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public List<int> Jours { get; set; }
        public List<int> Mois { get; set; }

        public AddDirectorUC()
        {
            InitializeComponent();
            DataContext = this;
            ChargementJoursMois();
        }

        public void ChargementJoursMois()
        {
            Jours = new List<int>();
            Mois = new List<int>();
            for (int i = 1; i < 32; i++)
            {
                Jours.Add(i);
            }
            for (int i = 1; i < 13; i++)
            {
                Mois.Add(i);
            }
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }

        private void AddDirector_Click(object sender, RoutedEventArgs e)
        {
            Personne directorToAdd;

            String Nom;
            String Prenom;
            String Nationalite;
            String Biographie;
            DateTime Naissance;
            DateTime? Mort;

            int NaissanceAnnee;
            int NaissanceMois;
            int NaissanceJour;

            int MortAnnee;
            int MortMois;
            int MortJour;

            if (String.IsNullOrWhiteSpace(NomDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format nom", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(PrenomDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format prénom", MessageBoxButton.OK);
                return;
            }
            try
            {
                NaissanceAnnee = Int32.Parse(NaissanceAnneeDirector.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Erreur format année de naissance", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(NationaliteDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format nationalité", MessageBoxButton.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(BiographieDirector.Text))
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format biographie", MessageBoxButton.OK);
                return;
            }
            if (NaissanceJourDirector.SelectedItem == null)
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format jour de naissance", MessageBoxButton.OK);
                return;
            }
            if (NaissanceMoisDirector.SelectedItem == null)
            {
                MessageBox.Show("Ce champ est nul ou non renseigné", "Erreur format mois de naissance", MessageBoxButton.OK);
                return;
            }

            NaissanceMois = Int32.Parse(NaissanceMoisDirector.SelectedItem.ToString());
            NaissanceJour = Int32.Parse(NaissanceJourDirector.SelectedItem.ToString());
            Naissance = new DateTime(NaissanceAnnee, NaissanceMois, NaissanceJour);

            //Exception levée quand j'exécute ce code à voir
            /*if (MortJourDirector.SelectedIndex != -1)
            {
                MortJour = Int32.Parse(MortJourDirector.SelectedItem.ToString());
                if (MortMoisDirector.SelectedIndex != -1)
                {
                    MortMois = Int32.Parse(MortMoisDirector.SelectedItem.ToString());
                    if (MortAnneeDirector.Text != null)
                    {
                        try
                        {
                            MortAnnee = Int32.Parse(MortAnneeDirector.Text);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur format année de mort", MessageBoxButton.OK);
                            return;
                        }
                        Mort = new DateTime(MortAnnee, MortMois, MortJour);
                    }
                    else
                    {
                        Mort = new DateTime?();
                    }
                }
                else
                {
                    Mort = new DateTime?();
                }
            }
            else
            {
                Mort = new DateTime?();
            }*/

            Nom = NomDirector.Text;
            Prenom = PrenomDirector.Text;
            Nationalite = NationaliteDirector.Text;
            Biographie = BiographieDirector.Text;

            /*if (Mort == null)
            {
                directorToAdd = new Personne(Nom, Prenom, Naissance, Nationalite, Biographie);
            }
            else
            {
                directorToAdd = new Personne(Nom, Prenom, Naissance, Mort, Nationalite, Biographie);
            }*/

            directorToAdd = new Personne(Nom, Prenom, Naissance, Nationalite, Biographie);

            LeManager.AjouterReal(directorToAdd);
            MessageBox.Show("Vous avez ajouter le réalisateur " + directorToAdd.Nom + " " + directorToAdd.Prenom + " avec succès.", "Ajout réalisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
        }
    }
}
