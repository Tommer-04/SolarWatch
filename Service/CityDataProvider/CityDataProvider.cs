using System.Net;

namespace SolarWatch.Service.CityDataProvider
{
    public class CityDataProvider : ICityDataProvider
    {
        public string GetCurrent(string city)
        {
            string apikey = "72a5927b3a5d27a0a5ff2d2de0171718";
            string url = $"https://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={apikey}";

            using var client = new WebClient();
            return client.DownloadString(url);         
        }
    }
}
