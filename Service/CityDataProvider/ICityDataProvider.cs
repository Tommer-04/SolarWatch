namespace SolarWatch.Service.CityDataProvider
{
    public interface ICityDataProvider
    {
        Task<string> GetCurrent(string city);
    }
}
