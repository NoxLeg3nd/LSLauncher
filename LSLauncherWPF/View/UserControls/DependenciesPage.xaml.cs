using System;
using System.IO;
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
using System.Diagnostics;

namespace LSLauncherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for DependenciesPage.xaml
    /// </summary>
    public partial class DependenciesPage : UserControl
    {
        public DependenciesPage()
        {
            InitializeComponent();
            SetupPage();
        }

        bool isSwInstalled = false;
        bool isUnityInstalled = false;
        bool isBasiliskInstalled = false;

        private void IfSwInstalled_Click(object sender, RoutedEventArgs e)
        {

            string path = "C:/Windows/SysWOW64/Adobe/Shockwave 12";
            if(Directory.Exists(path))
            {
                InstallSwButton.Visibility = Visibility.Collapsed;
                CheckSwInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                SwDependency.Text = $"Shockwave is properly installed at path {path}!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Green;
                isSwInstalled = true;
            }
            else {
                InstallSwButton.Visibility = Visibility.Visible;
                SwDependency.Text = "Shockwave 12 is not installed!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Red;
                isSwInstalled = false;
            }
        }
        private void IfUnityInstalled_Click(object sender, RoutedEventArgs e)
        {
            string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = System.IO.Path.Combine(userAppData.Replace("Local", "LocalLow"), @"Unity\WebPlayer");

            if (Directory.Exists(path))
            {
                InstallUnityButton.Visibility = Visibility.Collapsed;
                CheckUnityInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                UnityDependency.Text = $"Unity Web Player is properly installed at path {path}!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Green;
                isUnityInstalled = true;
            }
            else
            {
                InstallUnityButton.Visibility = Visibility.Visible;
                UnityDependency.Text = "Unity Web Player is not installed!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Red;
                isUnityInstalled = false;
            }
        }

        private void IfBasiliskInstalled_Click(object sender, RoutedEventArgs e)
        {

            string pathBasilisk = "C:/Program Files (x86)/Basilisk";
            if (Directory.Exists(pathBasilisk))
            {
                InstallBasiliskButton.Visibility = Visibility.Collapsed;
                CheckBasiliskInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                BasiliskDependency.Text = $"The Basilisk Web Browser is properly installed at path {pathBasilisk}!";
                BasiliskDependency.Foreground = System.Windows.Media.Brushes.Green;
                isBasiliskInstalled = true;
            }
            else
            {
                InstallBasiliskButton.Visibility = Visibility.Visible;
                BasiliskDependency.Text = "The Basilisk Web Browser is not installed!";
                BasiliskDependency.Foreground = System.Windows.Media.Brushes.Red;
                isBasiliskInstalled = false;
            }
        }

        private void InstallSwButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to install Shockwave 12?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                Process.Start("Assets/GameDependencies/Shockwave_Installer_Full.exe");
            }
        }
        private void InstallUnityButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to install Unity Web Player 2.6?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Process.Start("Assets/GameDependencies/unitywebplayer26.exe");
            }
        }

        private void InstallBasiliskButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to install the Basilisk 32bit Web Browser?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Process.Start("Assets/GameDependencies/basilisk-20250220144852.win32.installer.exe");
            }
        }

        private void RegistryInfo_Click(object sender, RoutedEventArgs e)
        {
            BrowserWindow browserWindow = new BrowserWindow("https://gaming.stackexchange.com/a/339841");
            browserWindow.Show();
        }

        private void NvidiaShockwaveFix_Click(object sender, RoutedEventArgs e)
        {
            IfSwInstalled_Click(sender, e);
            if (isSwInstalled is true)
            {
                Process.Start("Assets/GameDependencies/NVidiaShockwaveFix.exe");
            }
            else MessageBox.Show($"Shockwave 12 was not found. Are you sure it is installed?", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SetupPage()
        {
            string pathSw = "C:/Windows/SysWOW64/Adobe/Shockwave 12";
            if (Directory.Exists(pathSw))
            {
                InstallSwButton.Visibility = Visibility.Collapsed;
                CheckSwInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                SwDependency.Text = $"Shockwave is properly installed at path {pathSw}!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Green;
                isSwInstalled = true;
            }
            else
            {
                InstallSwButton.Visibility = Visibility.Visible;
                SwDependency.Text = "Shockwave 12 is not installed!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Red;
                isSwInstalled = false;
            }

            string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string pathUnity = System.IO.Path.Combine(userAppData.Replace("Local", "LocalLow"), @"Unity\WebPlayer");

            if (Directory.Exists(pathUnity))
            {
                InstallUnityButton.Visibility = Visibility.Collapsed;
                CheckUnityInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                UnityDependency.Text = $"Unity Web Player is properly installed at path {pathUnity}!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Green;
                isUnityInstalled = true;
            }
            else
            {
                InstallUnityButton.Visibility = Visibility.Visible;
                UnityDependency.Text = "Unity Web Player is not installed!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Red;
                isUnityInstalled = false;
            }

            string pathBasilisk = "C:/Program Files (x86)/Basilisk";
            if (Directory.Exists(pathBasilisk))
            {
                InstallBasiliskButton.Visibility = Visibility.Collapsed;
                CheckBasiliskInstalledButton.HorizontalAlignment = HorizontalAlignment.Center;
                BasiliskDependency.Text = $"The Basilisk Web Browser is properly installed at path {pathBasilisk}!";
                BasiliskDependency.Foreground = System.Windows.Media.Brushes.Green;
                isBasiliskInstalled = true;
            }
            else
            {
                InstallBasiliskButton.Visibility = Visibility.Visible;
                BasiliskDependency.Text = "The Basilisk Web Browser is not installed!";
                BasiliskDependency.Foreground = System.Windows.Media.Brushes.Red;
                isBasiliskInstalled = false;
            }
        }
    }
}
