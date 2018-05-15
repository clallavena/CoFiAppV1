using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager : IEnumerable<Film>, IEnumerable<Personne>
    {

        IEnumerable<Film> ChargementFilms();

        IEnumerable<Personne> ChargementPersonnes();

        void SauvegardeFilms(IEnumerable<Film> films);

        void SauvegardePersonnes(IEnumerable<Personne> personnes);

    }
}
