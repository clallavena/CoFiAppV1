using Metier;
using Metier.DataManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public Manager LeManager { get; set; } = new Manager(new DataContractManager());

        public NavigationManager NavManager { get; set; } = new NavigationManager();

    }
}
