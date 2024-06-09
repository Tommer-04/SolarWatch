using SolarWatch.Model;
using System.Text.Json;

namespace SolarWatch.Service.CityJsonProcessor
{
    public class CityJsonProcessor : ICityJsonProcessor
    {
        public City Process(string cityData)
        {
            JsonDocument json = JsonDocument.Parse(cityData);

            JsonElement main = json.RootElement[0];

            double lat = main.GetProperty("lat").GetDouble();
            double lon = main.GetProperty("lon").GetDouble();

            return new City(lat, lon);
        }
    }
}
