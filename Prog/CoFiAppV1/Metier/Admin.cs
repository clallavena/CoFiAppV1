using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// La classe Admin représente un utilisateur avec des droits supplémentaires. Il comporte un nom d'utilisateur et un mot de passe
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// Nom d'utilisateur de l'administrateur
        /// </summary>
        public string Username {
            get; private set;
        }

        /// <summary>
        /// Mot de passe de l'administrateur
        /// </summary>
        public string Password
        {
            get; private set;
        }

        /// <summary>
        /// Constructeur d'un administrateur avec un nom d'utilisateur et d'un mot de passe
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Méthode permettant à un administrateur de supprimer un film
        /// </summary>
        /// <param name="film"></param>
        public void SupprimerFilm(Film film)
        {

        }

        /// <summary>
        /// Méthode permettant à un administrateur de supprimer un réalisateur
        /// </summary>
        /// <param name="real"></param>
        public void SupprimerReal(Realisateur real)
        {

        }

        /// <summary>
        /// Méthode permettant à un administrateur de modifier les informations d'un film
        /// </summary>
        /// <param name="film"></param>
        /// <param name="titre"></param>
        /// <param name="dateDeSortie"></param>
        /// <param name="synopsis"></param>
        /// <param name="listTags"></param>
        public void ModifierFilm(Film film, string titre, int dateDeSortie, string synopsis, params string[] listTags)
        {

        }

        /// <summary>
        /// Méthode permettant à un administrateur de modifier les informations d'un réalisateur
        /// </summary>
        /// <param name="real"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="dateDeNaissance"></param>
        /// <param name="dateDeMort"></param>
        /// <param name="nationalite"></param>
        /// <param name="biographie"></param>
        public void ModiferReal(Realisateur real, string nom, string prenom, DateTime dateDeNaissance, DateTime dateDeMort, string nationalite, string biographie)
        {

        }

        /// <summary>
        /// Rédéfinition de la méthode ToString pour un meilleur affichage
        /// </summary>
        public override string ToString()
        {
            return $"Username: {Username} Password: {Password}";
        }

    }
}
