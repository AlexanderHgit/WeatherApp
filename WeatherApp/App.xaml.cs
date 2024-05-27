namespace WeatherApp;
using Microsoft.Maui.Controls;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        VersionTracking.Track();
        MainPage = new NavigationPage(new SettingsPage());
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 1400;
        const int newHeight = 700;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}
