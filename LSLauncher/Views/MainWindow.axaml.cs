using Avalonia.Controls;
using LSLauncher.Views.UserControls;
namespace LSLauncher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadHome();
        NavBarUserControl.HomeClicked += (_, __) => LoadHome();
        NavBarUserControl.SwGamesClicked += (_, __) => LoadSwGames();
        NavBarUserControl.UnityGamesClicked += (_, __) => LoadUnityGames();
        NavBarUserControl.DependenciesClicked += (_, __) => LoadDependencies();
    }
    public void LoadHome()
    {
        MainContentControl.Content = new HomePage();
    }
    public void LoadSwGames()
    {
        MainContentControl.Content = new SwGamesPage();
    }
    public void LoadUnityGames()
    {
        MainContentControl.Content = new UnityGamesPage();
    }
    public void LoadDependencies()
    {
        MainContentControl.Content = new DependenciesPage();
    }
}