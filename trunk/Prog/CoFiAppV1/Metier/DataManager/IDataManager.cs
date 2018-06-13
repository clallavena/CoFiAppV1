using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager
    {
        /// <summary>
        /// Chargement des films
        /// </summary>
        /// <returns></returns>
        IEnumerable<Film> ChargementFilms();

        /// <summary>
        /// Sauvegarde des films
        /// </summary>
        /// <param name="films"></param>
        void SauvegardeFilms(IEnumerable<Film> films);

        /// <summary>
        /// Chargement des réalisateurs
        /// </summary>
        /// <returns></returns>
        ObservableCollection<Personne> ChargementReal();
        
        /// <summary>
        /// Sauvegarde des réalisateurs
        /// </summary>
        /// <param name="personnes"></param>
        void SauvegardeReal(ObservableCollection<Personne> personnes);

        /// <summary>
        /// Chargement des administrateurs
        /// </summary>
        /// <returns></returns>
        IEnumerable<Admin> ChargementAdmin();

    }
}
