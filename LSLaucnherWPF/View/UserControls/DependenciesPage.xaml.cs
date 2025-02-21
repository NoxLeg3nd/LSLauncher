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

namespace LSLaucnherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for DependenciesPage.xaml
    /// </summary>
    public partial class DependenciesPage : UserControl
    {
        public DependenciesPage()
        {
            InitializeComponent();
        }

        private void IfSwInstalled_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:/Windows/SysWOW64/Adobe/Shockwave 12";
            if(Directory.Exists(path))
            {
                SwDependency.Text = $"Shockwave is properly installed at path {path}!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Green;
            }
            else {
                SwDependency.Text = "Shockwave 12 is not installed!";
                SwDependency.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
        private void IfUnityInstalled_Click(object sender, RoutedEventArgs e)
        {
            string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = System.IO.Path.Combine(userAppData.Replace("Local", "LocalLow"), @"Unity\WebPlayer");

            if (Directory.Exists(path))
            {
                UnityDependency.Text = $"Unity Web Player is properly installed at path {path}!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                UnityDependency.Text = "Unity Web Player is not installed!";
                UnityDependency.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
    }
}
