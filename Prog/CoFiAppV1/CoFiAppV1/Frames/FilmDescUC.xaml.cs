﻿using Metier;
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

namespace CoFiAppV1.Frames
{
    /// <summary>
    /// Logique d'interaction pour FilmDesc.xaml
    /// </summary>
    public partial class FilmDescUC : UserControl, INotifyPropertyChanged
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        private List<Personne> lp = new List<Personne>();

        public IEnumerable<Personne> Lp
        {
            get { return lp; }
            set { }
        }

        private List<Personne> lpa = new List<Personne>();

        public IEnumerable<Personne> Lpa
        {
            get { return lpa; }
            set { }
        }

        public FilmDescUC()
        {
            InitializeComponent();
            DataContext = this;

            lp = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Realisateur).SelectMany(s => s.Value).ToList();
            lpa = LeManager.FilmSelected.Personnes.Where(p => p.Key == Job.Acteur).SelectMany(s => s.Value).ToList();
        }

        /// <summary>
        /// Retourner à l'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.RechercherFilm(null, LeManager.Films);
            LeManager.FilmSelected = null;
        }

        /// <summary>
        /// Signalement d'un film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Signalement(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous signaler ce film ?", "Signalement", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result.ToString().Equals("Yes"))
            {
                try
                {
                    LeManager.Signaler(LeManager.FilmSelected);
                    MessageBox.Show("le signalement a été effectué avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("le signalement n'a pas pu être envoyé, veuillez contacter un administrateur ! \n" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Ajouter un réalisateur ou un film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous ajouter un Réalisateur ?", "Ajouter Réal", MessageBoxButton.YesNoCancel);

            if (result.ToString().Equals("Yes"))
            {
                NavManager.SelectedPart = NavManager.Parts["AddDirector"]();
            }
            else if (result.ToString().Equals("No"))
            {
                MessageBoxResult result2 = MessageBox.Show("Voulez-vous ajouter un Film ?", "Ajouter Film", MessageBoxButton.YesNoCancel);

                if (result2.ToString().Equals("Yes"))
                {
                    NavManager.SelectedPart = NavManager.Parts["AddFilm"]();
                }
            }
        }

        /// <summary>
        /// Supprimer un film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (LeManager.CurrentUser != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez vous supprimez ce film ?", "Supprimer", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result.ToString().Equals("Yes"))
                {
                    if (LeManager.SupprimerFilm(LeManager.FilmSelected))
                    {
                        MessageBox.Show("Suppression effectué avec succés", "Suppression", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        NavManager.SelectedPart = NavManager.Parts["Accueil"]();
                        LeManager.FilmSelected = null;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression", "Suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                NotifyPropertyChanged("LeManager.FilmsParNom");
                NavManager.SelectedPart = NavManager.Parts["Accueil"]();
                LeManager.FilmSelected = null;
            }
            else
            {
                MessageBox.Show("Il faut être administrateur!", "Permission non accordée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        /// <summary>
        /// Modifier un film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (LeManager.CurrentUser != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez vous modifier ce film ?", "Modifer", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result.ToString().Equals("Yes"))
                {
                    NavManager.SelectedPart = NavManager.Parts["ModifFilm"]();
                }
            }
            else
            {
                MessageBox.Show("Il faut être administrateur!", "Permission non accordée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Double clique sur un réalisateur pour avoir plus de détails sur lui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavManager.SelectedPart = NavManager.Parts["Director"]();
            LeManager.FilmSelected = null;
        }
    }
}
