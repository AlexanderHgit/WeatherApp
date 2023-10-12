using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public class SettingsServices 
    {

        public static async Task<string> AsyncGet(string key, dynamic defaultValue)
        {
            return await Preferences.Get(nameof(key),defaultValue);
        }

        public static async Task AsyncSet(string key,dynamic defaultValue)
        {
            await Preferences.Set(key, defaultValue);
        }
        public static void Set(string key, dynamic value)
        {
            Preferences.Default.Set(key, value);
        }
        public static dynamic Get(string key,dynamic defaultValue)
        {
            return Preferences.Default.Get(key,  defaultValue);
        }
    }
}
