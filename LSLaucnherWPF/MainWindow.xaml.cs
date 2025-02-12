using LSLaucnherWPF.View.UserControls;
using System.ComponentModel;
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

namespace LSLaucnherWPF
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

        private void LoadHome()
        {
            var homePage = new HomePage();
            MainContentControl.Content = homePage;
            currentPageType = typeof(HomePage);
        }

        private void LoadGames()
        {
            var gamesPage = new GamesPage();
            MainContentControl.Content = gamesPage;
            currentPageType = typeof(GamesPage);
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
            else if (currentPageType == typeof(GamesPage))
            {
                LoadGames();
            }
        }
    }
}
