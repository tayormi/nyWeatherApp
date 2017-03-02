using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyWeatherApp
{
    public class Core
    {
        public static async Task<weather> GetWeather(string ZipCode)
        {
            string key = "";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?" + ZipCode + ",us&appid=" + key + "&units=imperial";
            //<!--- For Programmers ---!>
            if (key == "my Api Key")
            {
                throw new ArgumentException("You must obtain an api key from Open Weather Map");
            }
            //return results
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                weather weather = new weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
