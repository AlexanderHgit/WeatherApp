using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'WeatherApp (net7.0-ios)'
Before:
using System.Threading.Tasks;
After:
using System.Threading.Tasks;
using WeatherApp;
using WeatherApp.Models;
using WeatherApp.Models;
using WeatherApp.Models.OpenWeather;
*/
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public String dateTime => GlobalServices.ParseDateTime(dt_txt).ToString("h tt");
        public DateTime was => GlobalServices.ParseDateTime(dt_txt);
        public DayOfWeek what => was.DayOfWeek;
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temperature => Math.Round(temp);
        public string temp_symb => temperature.ToString()+ "°C";
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Rain
    {
        public double _3h { get; set; }
    }

    public class ForecastRoot
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }
    public class WeatherRoot
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    public class Sys
    {
        public string pod { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string fullIconUrl => string.Format("http://openweathermap.org/img/wn/{0}@2x.png", icon);
        public string customIcon => string.Format("icon_{0}.png", icon);
    }
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }
    // GooglePrediction
    public class MainTextMatchedSubstring
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class MatchedSubstring
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class Prediction
    {
        public string description { get; set; }
        public List<MatchedSubstring> matched_substrings { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public StructuredFormatting structured_formatting { get; set; }
        public List<Term> terms { get; set; }
        public List<string> types { get; set; }
    }

    public class PreRoot
    {
        public List<Prediction> predictions { get; set; }
        public string status { get; set; }
    }

    public class SecondaryTextMatchedSubstring
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class StructuredFormatting
    {
        public string main_text { get; set; }
        public List<MainTextMatchedSubstring> main_text_matched_substrings { get; set; }
        public string secondary_text { get; set; }
        public List<SecondaryTextMatchedSubstring> secondary_text_matched_substrings { get; set; }
    }

    public class Term
    {
        public int offset { get; set; }
        public string value { get; set; }
    }
    //Google getphoto
    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Result
    {
        public List<Photo> photos { get; set; }
    }

    public class PostRoot
    {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }


}
