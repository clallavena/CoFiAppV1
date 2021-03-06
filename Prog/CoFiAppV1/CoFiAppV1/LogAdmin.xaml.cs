﻿using CoFiAppV1.Frames;
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
using System.Windows.Shapes;

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour LogAdmin.xaml
    /// </summary>
    public partial class LogAdmin : Window
    {
        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public LogAdmin()
        {
            InitializeComponent();
            Username_TextBox.Focus();
        }

        /// <summary>
        /// Quitter la fenêtre administrateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se connecter avec un compte administrateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            Connexion();
        }

        /// <summary>
        /// Effectuer une connexion en appuyant sur la touche entrée après avoir rentré le mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassWord_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Connexion();
            }
        }

        /// <summary>
        /// Fonction de connexion pour administrateur
        /// </summary>
        private void Connexion()
        {
            string username = Username_TextBox.Text;
            string password = PassWord_TextBox.Password;

            Admin admin = new Admin(username, password);

            foreach (Admin a in LeManager.ListAdmin)
            {
                if (a.Equals(admin))
                {
                    LeManager.CurrentUser = admin;
                    MessageBox.Show("Connection Effectué avec succés", "Bienvenue Administrateur", MessageBoxButton.OK);
                    this.Close();
                    return;
                }
            }

            MessageBox.Show("Nom d'utilisateur ou Mot de passe incorrecte", "Erreur connexion", MessageBoxButton.OK);
        }

        /// <summary>
        /// Fonction pour se déconnecter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deconnection_Click(object sender, RoutedEventArgs e)
        {
            if (LeManager.CurrentUser != null)
            {
                LeManager.CurrentUser = null;
                MessageBox.Show("Déconnexion effectué avec succés!", "Déconnexion réussi", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Vous n'êtes pas connecté en tant qu'administrateur", "Erreur Deconnexion", MessageBoxButton.OK);
            }
        }
    }
}
