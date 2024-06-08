namespace WeatherApp;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}
    private async void clothes(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new WeatherPage());
	}
}