using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Services
{
    public static class ApiService
    {
        public static async Task<ForecastRoot> GetForecastByGps(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid={2}", latitude,longitude, GlobalServices.OpenAPI));
            return JsonConvert.DeserializeObject<ForecastRoot>(response);
        
        }

        public static async Task<ForecastRoot> GetForecastByCity(string city)
        {
            var httpClient = new HttpClient();
            dynamic namereq;
            dynamic name;
            dynamic response;
            if (GlobalServices.IsNumeric(city))
            {
                Debug.WriteLine("true");
                namereq = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/geo/1.0/zip?zip={0},US&appid={1}", city, GlobalServices.OpenAPI));
                name = JsonConvert.DeserializeObject<zipinfo>(namereq).name;
                response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid={1}", name, GlobalServices.OpenAPI));
            }
            else
            {


                response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid={1}", city, GlobalServices.OpenAPI));
            }
            return JsonConvert.DeserializeObject<ForecastRoot>(response);

        }
        public static async Task<WeatherRoot> GetWeatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid={1}", city, GlobalServices.OpenAPI));
            return JsonConvert.DeserializeObject<WeatherRoot>(response);
        }
        public static async Task<WeatherRoot> GetWeatherByGPS(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid={2}", latitude, longitude, GlobalServices.OpenAPI));
            return JsonConvert.DeserializeObject<WeatherRoot>(response);
        }
        public static async Task<PreRoot> GetLocation(string location)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&types=(cities)&key={1}", location, GlobalServices.PlaceAPI));
            return JsonConvert.DeserializeObject<PreRoot>(response);


        }

            public static async Task<String> GetPhoto(string location_id)
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/details/json?place_id={0}&fields=photo&key={1}", location_id, GlobalServices.PlaceAPI));
                var jresponse = JsonConvert.DeserializeObject<PostRoot>(response);

                var photo_ref = jresponse.result.photos[0].photo_reference;
                var image_url = string.Format("https://maps.googleapis.com/maps/api/place/photo?maxwidth=1600&photoreference={0}&key={1}", photo_ref, GlobalServices.PlaceAPI);

                return image_url;
            }

       
    }
}
