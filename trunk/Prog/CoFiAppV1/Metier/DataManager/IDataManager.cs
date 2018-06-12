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

        IEnumerable<Film> ChargementFilms();

        void SauvegardeFilms(IEnumerable<Film> films);

        ObservableCollection<Personne> ChargementReal();
        
        void SauvegardeReal(ObservableCollection<Personne> personnes);

        IEnumerable<Admin> ChargementAdmin();

    }
}
