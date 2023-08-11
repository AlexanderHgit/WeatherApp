using System;
using System.Collections.Generic;
using System.Linq;
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
        public static String GetUnixCurrentTime(long unixTime)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpoch.AddSeconds(unixTime).ToString("h tt");
        }

        public static DateTime ConvertToTimeZone(DateTime inputDateTime, TimeZoneInfo targetTimeZone)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTime(inputDateTime, targetTimeZone);
            return convertedTime;
        }
        public static bool ConvertUnixTimeZone()
        {
            return false;
        }

    }

}
     
