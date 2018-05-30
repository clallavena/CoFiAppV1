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
        public string Username
        {
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

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Admin);
        }
        public bool Equals(Admin admin)
        {
            return (this.Username == admin.Username && this.Password == admin.Password);
        }

        /// <summary>
        /// Rédéfinition de la méthode ToString pour un meilleur affichage
        /// </summary>
        public override string ToString()
        {
            return $"Username: {Username} Password: {Password}";
        }

        public override int GetHashCode()
        {
            var hashCode = 568732665;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
