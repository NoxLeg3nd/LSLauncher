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
    public event EventHandler? UnityGamesClicked;
    public event EventHandler? DependenciesClicked;
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
       UnityGamesClicked?.Invoke(this, EventArgs.Empty);
    }

    private void ModsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (OperatingSystem.IsWindows())
        {
            System.Diagnostics.Process.Start("https://sites.google.com/view/burnin-rubber-mod-hub/home");
        }
        else if (OperatingSystem.IsLinux())
        {
            System.Diagnostics.Process.Start("xdg-open", "https://sites.google.com/view/burnin-rubber-mod-hub/home");
        }
    }
    
    private void DependenciesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        DependenciesClicked?.Invoke(this, EventArgs.Empty);
    }
}