
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;

namespace LSLauncher.Views;

public partial class SplashWindow : Window
{
	public SplashWindow()
	{
		InitializeComponent();
		OpenMainWindowAsync();
	}

	private async void OpenMainWindowAsync()
	{
		await Task.Delay(3000);
		var mainWindow = new MainWindow();
		mainWindow.Show();
		this.Close();
	}
}