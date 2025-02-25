using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LSLauncherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for UnityGamesPage.xaml
    /// </summary>
    public partial class UnityGamesPage : UserControl
    {
        public UnityGamesPage()
        {
            InitializeComponent();
            UnityLSVideo.Source = new Uri(System.IO.Path.GetFullPath("Assets/Website/LSLUnity.mp4"));
            UnityInfoBorder.Visibility = Properties.Settings.Default.BorderVisibility == "Visible" ? Visibility.Visible : Visibility.Visible; //Change this to Collapsed hide it forever (even after app restart)
        }
        private void UnityLSVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            UnityLSVideo.Position = TimeSpan.Zero;
            UnityLSVideo.Play();
        }

        private void DiscordJoin_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://discord.com/invite/3w3EC5W",
                UseShellExecute = true
            });
        }

        private void UnityInfoButton_Click(object sender, RoutedEventArgs e)
        {
            UnityInfoBorder.Visibility = Visibility.Collapsed;
            Properties.Settings.Default.BorderVisibility = "Collapsed";
            Properties.Settings.Default.Save();
        }
        private void UnityInfoDependency_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).LoadDependencies();
        }

        private void UnityInfo_Click(object sender, RoutedEventArgs e)
        {
            BrowserWindow browserWindow = new BrowserWindow("https://en.wikipedia.org/wiki/Unity_(game_engine)");
            browserWindow.Show();
        }
    }
}
