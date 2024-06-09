using SolarWatch.Model;

namespace SolarWatch.Service.CityJsonProcessor
{
    public interface ICityJsonProcessor
    {
        City Process(string cityData);
    }
        
}
