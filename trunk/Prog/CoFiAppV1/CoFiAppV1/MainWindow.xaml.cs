﻿using CoFiAppV1.Frames;
using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoFiAppV1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Func<UserControl>> Parts { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            ["FilmDesc"] = () => new FilmDescUC(),
        };

        public Manager LeManager
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LeManager.Chargement();
            DataContext = LeManager;
        }
        
    }
}
