using LSLauncherWPF.View.UserControls;
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

        public void LoadUnityGames()
        {
            var unityGamesPage = new UnityGamesPage();
            MainContentControl.Content = unityGamesPage;
            currentPageType = typeof(UnityGamesPage);
        }

        public void SwLoadSBS()
        {
            var sbsPage = new SBSPage(1, "Shockwave");
            MainContentControl.Content = sbsPage;
            currentPageType = typeof(SBSPage);
        }

        public void UnityLoadSBS()
        {
            var sbsPage = new SBSPage(1, "Unity");
            MainContentControl.Content = sbsPage;
            currentPageType = typeof(SBSPage);
        }

        public void SwLoadXform()
        {
            var xformPage = new XformPage(6, "Shockwave");
            MainContentControl.Content = xformPage;
            currentPageType = typeof(XformPage);
        }


        public void UnityLoadXform()
        {
            var xformPage = new XformPage(6, "Unity");
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
            switch (currentPageType.Name)
            {
                case nameof(HomePage):
                    LoadHome();
                    break;
                case nameof(SwGamesPage):
                    LoadSwGames();
                    break;
                case nameof(UnityGamesPage):
                    LoadUnityGames();
                    break;
                case nameof(DependenciesPage):
                    LoadDependencies();
                    break;
                case nameof(XformPage):
                    if (MainContentControl.Content is XformPage xformPage)
                    {
                        if (xformPage.Platform == "Shockwave")
                        {
                            SwLoadXform();
                        }
                        else if (xformPage.Platform == "Unity")
                        {
                            UnityLoadXform();
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unhandled page type: {currentPageType.Name}");
            }
            if (MainContentControl.Content is HomePage homePage)
            {
                homePage.Cleanup();
            }
        }
    }
}
