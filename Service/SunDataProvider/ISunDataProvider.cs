namespace SolarWatch.Service.SunDataProvider
{
    public interface ISunDataProvider
    {
        Task<string> GetCurrent(double lat, double lon);
    }
}
