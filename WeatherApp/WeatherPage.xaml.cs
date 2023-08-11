using System.Diagnostics;
using WeatherApp.Services;
using System.Timers;

using static System.Net.WebRequestMethods;
using Microsoft.Maui.Animations;
using System.Net;
using System;


namespace WeatherApp;

public partial class WeatherPage : ContentPage
{

/* Unmerged change from project 'WeatherApp (net6.0-android)'
Before:
    public List<Models.List> WeatherList;
After:
    public List<List> WeatherList;
*/

/* Unmerged change from project 'WeatherApp (net7.0-ios)'
Before:
    public List<Models.OpenWeather.List> WeatherList;
After:
    public List<List> WeatherList;
*/
    public List<Models.List> WeatherList;
    private double latitude;
    private double longitude;
	public WeatherPage()
	{
		InitializeComponent();

/* Unmerged change from project 'WeatherApp (net6.0-android)'
Before:
        WeatherList = new List<Models.List>();
After:
        WeatherList = new List<List>();
*/

/* Unmerged change from project 'WeatherApp (net7.0-ios)'
Before:
        WeatherList = new List<Models.OpenWeather.List>();
After:
        WeatherList = new List<List>();
*/
        WeatherList = new List<Models.List>();
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await GetLocation();
  }

    public async Task GetLocation()
    {
        var location = await Geolocation.GetLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;
    }
    private async void ClickLocation_Tapped(object sender, EventArgs e)
    {
        await GetLocation();
        await GetWeatherDataByLocation(latitude, longitude);

    }
    public async Task GetWeatherDataByLocation(double latitude, double longitude)
    {
        var forecast = await ApiService.GetForecastByGps(latitude, longitude);
        var weather = await ApiService.GetWeatherByGPS(latitude, longitude);
        UpdateUI(weather,forecast);
    }
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayPromptAsync(title: "", message: "", placeholder: "Search weather by city",accept:"Search",cancel:"Cancel");
        if (response != null)
        {
            await GetWeatherDataByCity(response);
        }
   }
    public async Task GetWeatherDataByCity(string city)
    {
        var weather = await ApiService.GetWeatherByCity(city);
        var forecast = await ApiService.GetForecastByCity(city);
        UpdateUI(weather,forecast);
    }
    public async Task GetLocationImage(string location)
    {
        var result = await ApiService.GetLocation(location);
        var image_src = await ApiService.GetPhoto(result.predictions[0].place_id);
        UpdateBG(image_src);
    }
    public async void UpdateUI(dynamic weather , dynamic forecast)
    {
        await MainGrid.FadeTo(0, 1000, Easing.Linear);
    
        foreach (var item in forecast.list)
        {
            WeatherList.Add(item);

        }
        CvWeather.ItemsSource = WeatherList;

        LblCity.Text = forecast.city.name;
    
        LblWeatherDescription.Text = weather.weather[0].description;
        LblTemperature.Text = weather.main.temp.ToString();//result.list[0].main.temperature + "°C";
        LblHumidity.Text = weather.main.humidity + "%";
        LblWind.Text = weather.wind.speed + "km/h";
        LblCurrentDay.Text = GlobalServices.GetUnixCurrentTime(weather.dt);
        ImgWeatherIcon.Source = weather.weather[0].customIcon;
        GetLocationImage(forecast.city.name);
        
    }

    public async void UpdateBG(string src)
    {
        
        var image = src;
        var imagesource = await ImageLoader.LoadImageFromUriAsync(image);
 
        
        BGImage.Source=src;
        BGImage.Source = src;
        if (imagesource != null)
        {
            BGImage.Source = imagesource;
            await MainGrid.FadeTo(1, 1000, Easing.Linear);
        }
    }
}  