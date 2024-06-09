using System.Net;

namespace SolarWatch.Service.SunDataProvider
{
    public class SunDataProvider : ISunDataProvider
    {
        public string GetCurrent(double lat, double lon)
        {
            string url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lon}";

            var client = new WebClient();

            return client.DownloadString(url) ;
        }
    }
}
