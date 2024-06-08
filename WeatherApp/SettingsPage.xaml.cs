using System.Diagnostics;
using WeatherApp.Services;


namespace WeatherApp;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		
		InitializeComponent();
        bgGrid.BackgroundColor = GlobalServices.GetbgColor();
        SettingsGrid.Background = GlobalServices.GetGradient();
		PicTimeZone.SelectedIndex = 0;
		PicTempScale.SelectedIndex = 0;
        EntWeatherApi.Text = GlobalServices.OpenAPI;
        EntGoogApi.Text = GlobalServices.PlaceAPI;

    }
    protected async override void OnAppearing()
    {
        await SettingsGrid.FadeTo(1, 1000, Easing.Linear);
       
    }
    async void OnButtonClicked(object sender, EventArgs E)
	{
		SettingsServices.Set("TimeZone", PicTimeZone.SelectedItem.ToString());
		SettingsServices.Set("ClimateScale", PicTempScale.SelectedItem.ToString()) ;
        SettingsServices.Set("BackgroundToggleOff", SwiBG.IsToggled);
        GlobalServices.OpenAPI = EntWeatherApi.Text;
        GlobalServices.PlaceAPI = EntGoogApi.Text;
        await SettingsGrid.FadeTo(0, 1000, Easing.Linear);
       
        
        await Navigation.PushAsync(new WeatherPage(), false);
       
    }
	void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		
		PicTimeZone.TextColor=Colors.Red;
		
	
	}
    }