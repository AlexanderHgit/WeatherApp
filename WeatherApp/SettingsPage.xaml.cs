using WeatherApp.Services;

namespace WeatherApp;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		SettingsGrid.Background = GlobalServices.GetGradient();
		PicTimeZone.SelectedIndex = 0;
		PicTempScale.SelectedIndex = 0;
	}
	async void OnButtonClicked(object sender, EventArgs E)
	{
		SettingsServices.Set("TimeZone", PicTimeZone.SelectedItem.ToString());
		SettingsServices.Set("ClimateScale", PicTempScale.SelectedItem.ToString()) ;
        SettingsServices.Set("BackgroundToggleOff", SwiBG.IsEnabled);
        await Navigation.PushModalAsync(new WeatherPage());
		//get a auto zipcode thingy 
		//remove animation toiggle because i dont fucking careeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee itsssssssssssssssssssssssssss daujsihwrnghkjbaseeeeedfsssssssssssssssssssssss
    }
}