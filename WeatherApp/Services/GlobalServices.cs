
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    class GlobalServices
    {
        private static string v_PlaceAPI = "AIzaSyDF34OPzGr7oKIvgej72P6gtiTqrNGWWr0";
        public static string PlaceAPI
        {
            get { return v_PlaceAPI; }
            set { v_PlaceAPI = value; }
        }
        private static string v_OpenAPI = "50004dac5bb8939d9ab28551340d7670";
        public static string OpenAPI
        {
            get { return v_OpenAPI; }
            set { v_OpenAPI = value; }
        }
        private static string v_BodyTextColor = "Red";
        public static string BodyTextColor
        {
            get { return v_BodyTextColor; }
            set { v_BodyTextColor = value; }
        }
      
                        

        public static DateTime ParseDateTime(string input)
        {
            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            return DateTime.MinValue;
        }
        public static String GetCurrentDay(string input)
        {
            var stuff = ParseDateTime(input);
            return stuff.DayOfWeek.ToString();
        }
        public static String GetCurrentTime(string input)
        {
            return GlobalServices.ParseDateTime(input).ToString("h tt");
        }
        public static DateTime GetUnixCurrentTime(long unixTime)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpoch.AddSeconds(unixTime);
        }

        public static DateTime ConvertToTimeZone(DateTime inputDateTime, TimeZoneInfo targetTimeZone)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTime(inputDateTime, targetTimeZone);
            return convertedTime;
        }
        public static String ConvertUnixToTimeZone(dynamic unixTime, string format)
        {

            string timeZone = "";
            switch (SettingsServices.Get("TimeZone", "EST"))
            {
                case "EST":
                    timeZone = "Eastern Standard Time";
                    break;
                case "CST":
                    timeZone = "Central Standard Time";
                    break;
                case "MST":
                    timeZone = "Mountain Standard Time";
                    break;
                case "PST":
                    timeZone = "Pacific Standard Time";
                    break;

            }
            var current_time = GetUnixCurrentTime(unixTime);
            var zone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(current_time, timeZone);
            return zone.ToString(format);
        }
        /* work on this */

        public static String GetTempScaleTemp(dynamic temp)
        {
            
            double dTemp = double.Parse(temp);
            string newTemp = "";
            switch (SettingsServices.Get("ClimateScale", "Celsius (°C)"))
            {
                case "Celsius (°C)":
                    double stuff = Math.Ceiling(Convert.ToDouble(temp));
                    newTemp = stuff.ToString()+ " °C"; 
                    break;
                case "Fahrenheit (°F)":
                    newTemp = ((dTemp * 1.8) + 32).ToString("F0")+ " °F"; break;
            }
            return newTemp;
        }
        public static string GetBackgroundImage(string image)
        {
            switch (SettingsServices.Get("BackgroundToggle", true))
            {
                case false:
                    return image;
                   
                case true:
                    return null;



            }
            return null;

        }
        public static LinearGradientBrush GetGradient()
        {


            var gradientBrush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
           Debug.WriteLine(DateTime.Now);
            DateTime currentTime = DateTime.Now;

            // Create a DateTime object representing 6 PM
            DateTime sixPM = DateTime.Today.AddHours(18);

            // Compare the current time with 6 PM
            if (currentTime < sixPM)
            {

                gradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0));
                gradientBrush.GradientStops.Add(new GradientStop(Colors.LightBlue, 1));
            }
            else
            {
                gradientBrush.GradientStops.Add(new GradientStop(Colors.LightBlue, 0));
                gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 1));
            }
            return gradientBrush;

        }

    }
}
     
