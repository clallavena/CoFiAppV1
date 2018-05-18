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
        private Manager manager = new Manager(new StubDataManager());

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).manager;
            }
        }        

    }
}
