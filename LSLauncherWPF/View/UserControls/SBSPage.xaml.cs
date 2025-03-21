﻿using System;
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
using Windows.Foundation.Metadata;

namespace LSLauncherWPF.View.UserControls
{
    /// <summary>
    /// Interaction logic for SBSPage.xaml
    /// </summary>
    public partial class SBSPage : UserControl
    {
        private DatabaseHelper _databaseHelper = new DatabaseHelper();
        public string Platform { get; private set; }
        public SBSPage(int developerId, string platform)
        {
            Platform = platform;
            InitializeComponent();
            LoadGames(developerId, platform);
        }
        private void LoadGames(int developerId, string platform)
        {
            var games = _databaseHelper.GetGamesByDeveloperAndPlatform(developerId, platform);
            foreach (var game in games)
            {
                GamesPanel.Children.Add(CreateGameCard(game));
            }
        }

        private Border CreateGameCard(Games game)
        {
            var button = new Button
            {
                Content = "Download!",
                Background = System.Windows.Media.Brushes.Green,
                Foreground = System.Windows.Media.Brushes.White,
                Margin = new System.Windows.Thickness(5),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Tag = game.GameLink
            };
            button.Click += OpenGameLink;

            var card = new Border
            {
                Margin = new System.Windows.Thickness(10),
                Child = new StackPanel
                {
                    Children =
                    {
                        new Image
                        {
                            Source = new BitmapImage(new System.Uri(game.ImagePath, System.UriKind.RelativeOrAbsolute)),
                            Height = 182,
                            Width = 364,
                            Stretch = System.Windows.Media.Stretch.UniformToFill
                        },
                        new TextBlock
                        {
                            Text = game.GameName,
                            Foreground = System.Windows.Media.Brushes.White,
                            FontSize = 20,
                            FontWeight = System.Windows.FontWeights.Bold,
                            TextAlignment = TextAlignment.Center,
                            Margin = new System.Windows.Thickness(5)
                        },
                        button
                    }
                }
            };
            return card;
        }
        private void OpenGameLink(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string url)
            {
                try
                {
                    BrowserWindow browserWindow = new BrowserWindow(url);
                    browserWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open link: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
