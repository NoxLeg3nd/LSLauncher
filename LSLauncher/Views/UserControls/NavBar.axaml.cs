using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Markup.Xaml;

namespace LSLauncher.Views.UserControls;

public partial class NavBar : UserControl
{
    public event EventHandler? HomeClicked;
    public event EventHandler? SwGamesClicked;
    public NavBar()
    {
        InitializeComponent();
    }
    
    private void HomeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        HomeClicked?.Invoke(this, EventArgs.Empty);
    }

    private void SwGamesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        SwGamesClicked?.Invoke(this, EventArgs.Empty);
    }

    private void UnityGamesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ModsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void DependenciesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}