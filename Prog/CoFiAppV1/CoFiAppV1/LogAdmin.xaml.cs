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
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            Connexion();
        }

        private void PassWord_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Connexion();
            }
        }

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
    }
}
