namespace SolarWatch.Service.SunDataProvider
{
    public interface ISunDataProvider
    {
        string GetCurrent(double lat, double lon);
    }
}
