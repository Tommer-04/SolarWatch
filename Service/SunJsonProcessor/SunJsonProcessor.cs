using SolarWatch.Model;
using System.Text.Json;

namespace SolarWatch.Service.SunJsonProcessor
{
    public class SunJsonProcessor : ISunJsonProcessor
    {
        public Sun Process(string sunData)
        {
            JsonDocument json = JsonDocument.Parse(sunData);

            JsonElement results = json.RootElement.GetProperty("results");

            string sunrise = results.GetProperty("sunrise").GetString();
            string sunset = results.GetProperty("sunset").GetString();

            TimeOnly sunriseTime = TimeOnly.Parse(sunrise);
            TimeOnly sunsetTime = TimeOnly.Parse(sunset);

            return new Sun(sunriseTime, sunsetTime);
        }
    }
}
