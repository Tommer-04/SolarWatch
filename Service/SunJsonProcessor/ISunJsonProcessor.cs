using SolarWatch.Model;

namespace SolarWatch.Service.SunJsonProcessor
{
    public interface ISunJsonProcessor
    {
        Sun Process(string sunData);
    }
}
