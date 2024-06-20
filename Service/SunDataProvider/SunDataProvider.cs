using System.Net;

namespace SolarWatch.Service.SunDataProvider
{
    public class SunDataProvider : ISunDataProvider
    {
        public async Task<string> GetCurrent(double lat, double lon)
        {
            string url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lon}";

            var client = new HttpClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
