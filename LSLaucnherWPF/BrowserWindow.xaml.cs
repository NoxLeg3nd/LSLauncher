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
using System.Windows.Shapes;

namespace LSLaucnherWPF
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        public BrowserWindow(string url)
        {
            InitializeComponent();
            LoadUrl(url);
        }

        private async void LoadUrl(string url)
        {
            await WV2BrowserWindow.EnsureCoreWebView2Async();
            WV2BrowserWindow.Source = new Uri(url);
        }

        private void BrowserBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (WV2BrowserWindow.CanGoBack)
            {
                WV2BrowserWindow.GoBack();
            }
        }

        private void BrowserForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (WV2BrowserWindow.CanGoForward)
            {
                WV2BrowserWindow.GoForward();
            }
        }

        private void BrowserRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            WV2BrowserWindow.Reload();
        }

        private void BrowserCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
