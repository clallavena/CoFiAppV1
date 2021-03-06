﻿using CoFiAppV1.Frames;
using Metier;
using System;
using System.Collections.Generic;
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

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NavigationManager NavManager => (Application.Current as App).NavManager;

        public Dictionary<string, Func<UserControl>> Parts => (Application.Current as App).NavManager.Parts;

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DataContext = this;
        }

        /// <summary>
        /// Evenement exécuté lorsque l'on change l'élément sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LeManager.FilmSelected != null)
            {
                NavManager.SelectedPart = NavManager.Parts["FilmDesc"]();
            }
        }

        /// <summary>
        /// Evenement exécuté lors de la fermeture de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            LeManager.Sauvegarde();
        }

        /// <summary>
        /// Evenement exécuté lors de l'initialisation de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LeManager.Chargement();
            NavManager.SelectedPart = NavManager.Parts["Accueil"]();
            LeManager.FilmSelected = null;
        }
    }
}