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

using Microsoft.Web.WebView2.Core;

namespace LSLaucnherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            LoadYoutubeTrailer();
        }
        private async void LoadYoutubeTrailer()
        {
            await LSTrailer.EnsureCoreWebView2Async();
            string embedURL = $"https://www.youtube.com/embed/59WsFW0WKTY?si=Ok5oDQKGfdoohvy2";
            LSTrailer.Source = new Uri(embedURL);
        }
    }
}
