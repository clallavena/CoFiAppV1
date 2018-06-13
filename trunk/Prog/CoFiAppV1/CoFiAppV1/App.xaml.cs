using Metier;
using Metier.DataManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
        /// <summary>
        /// Manager du code behind
        /// </summary>
        public Manager LeManager { get; set; } = new Manager(new DataContractManager());

        /// <summary>
        /// Permet de naviguer entre les différents UserControls
        /// </summary>
        public NavigationManager NavManager { get; set; } = new NavigationManager();
                
    }
}
