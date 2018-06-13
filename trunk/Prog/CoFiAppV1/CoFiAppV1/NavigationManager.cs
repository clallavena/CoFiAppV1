using CoFiAppV1.Frames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoFiAppV1
{
    public class NavigationManager : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary<string, Func<UserControl>> Parts { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            ["FilmDesc"] = () => new FilmDescUC(),
            ["Accueil"] = () => new AccueilUC(),
            ["AddDirector"] = () => new AddDirectorUC(),
            ["AddFilm"] = () => new AddFilmUC(),
            ["Director"] = () => new DirectorUC(),
            ["Independant"] = () => new IndependantUC(),
            ["ModifFilm"] = () => new ModifFilmUC(),
        };
        
        void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private UserControl selectedPart;

        public UserControl SelectedPart
        {
            get { return selectedPart; }
            set { selectedPart = value; OnPropertyChanged(); }
        }
    }
}
