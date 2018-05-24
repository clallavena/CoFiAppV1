using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager
    {

        IEnumerable<Film> ChargementFilms();

        void SauvegardeFilms(IEnumerable<Film> films);
        IEnumerable<Personne> ChargementReal();

    }
}
