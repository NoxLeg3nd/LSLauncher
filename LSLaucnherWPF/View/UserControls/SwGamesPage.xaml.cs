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

namespace LSLaucnherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for SwGamesPage.xaml
    /// </summary>
    public partial class SwGamesPage : UserControl
    {
        public SwGamesPage()
        {
            InitializeComponent();
            SwLSVideo.Source = new Uri(System.IO.Path.GetFullPath("Assets/Website/lsgif3_cropped.wmv"));
            SwInfoBorder.Visibility = Properties.Settings.Default.BorderVisibility == "Visible" ? Visibility.Visible : Visibility.Visible; //Change this to Collapsed hide it forever (even after app restart)
        }
        private void SwLSVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            SwLSVideo.Position = TimeSpan.Zero;
            SwLSVideo.Play();
        }
        private void SwInfoButton_Click(object sender, RoutedEventArgs e)
        {
            SwInfoBorder.Visibility = Visibility.Collapsed;
            Properties.Settings.Default.BorderVisibility = "Collapsed";
            Properties.Settings.Default.Save();
        }
        private void SWInfo_Click(object sender, RoutedEventArgs e)
        {
            BrowserWindow browserWindow = new BrowserWindow("https://en.wikipedia.org/wiki/Adobe_Shockwave_Player");
            browserWindow.Show();
        }

        private void DiscordJoin_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://discord.com/invite/3w3EC5W",
                UseShellExecute = true
            });
        }
    }
}
