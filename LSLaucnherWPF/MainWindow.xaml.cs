﻿using LSLauncherWPF.View.UserControls;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LSLauncherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Type currentPageType;

        public MainWindow()
        {
            InitializeComponent();
            LoadHome();
        }

        public void LoadHome()
        {
            var homePage = new HomePage();
            MainContentControl.Content = homePage;
            currentPageType = typeof(HomePage);
        }

        public void LoadSwGames()
        {
            var swGamesPage = new SwGamesPage();
            MainContentControl.Content = swGamesPage;
            currentPageType = typeof(SwGamesPage);
        }

        public void LoadXform()
        {
            var xformPage = new XformPage(6);
            MainContentControl.Content = xformPage;
            currentPageType = typeof(XformPage);
        }

        public void LoadDependencies()
        {
            var dependenciesPage = new DependenciesPage();
            MainContentControl.Content = dependenciesPage;
            currentPageType = typeof(DependenciesPage);
        }

        private void RefreshContentButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshCurrentPage();
        }

        private void RefreshCurrentPage()
        {
            if (MainContentControl.Content is HomePage homePage)
            {
                homePage.Cleanup();
            }
            if (currentPageType == typeof(HomePage))
            {
                LoadHome();
            }
            else if (currentPageType == typeof(SwGamesPage))
            {
                LoadSwGames();
            }
        }
    }
}
