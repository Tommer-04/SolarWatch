using Microsoft.AspNetCore.Mvc;
using SolarWatch.Model;
using SolarWatch.Service.CityDataProvider;
using SolarWatch.Service.CityJsonProcessor;
using SolarWatch.Service.SunDataProvider;
using SolarWatch.Service.SunJsonProcessor;
using System.ComponentModel.DataAnnotations;

namespace SolarWatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarWatchController : ControllerBase
    {
        private readonly ILogger<SolarWatchController> _logger;
        private readonly ICityDataProvider _cityDataProvider;
        private readonly ICityJsonProcessor _cityJsonProcessor;
        private readonly ISunDataProvider _sunDataProvider;
        private readonly ISunJsonProcessor _sunJsonProcessor;
        public SolarWatchController(ILogger<SolarWatchController> logger, ICityDataProvider cityDataProvider, ICityJsonProcessor cityJsonProcessor, ISunDataProvider sunDataProvider, ISunJsonProcessor sunJsonProcessor)
        {
            _logger = logger;
            _cityDataProvider = cityDataProvider;
            _cityJsonProcessor = cityJsonProcessor;
            _sunDataProvider = sunDataProvider;
            _sunJsonProcessor = sunJsonProcessor;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([Required] string city)
        {
            var cityData = await _cityDataProvider.GetCurrent(city);

            if(cityData == "[]") 
            {
                return NotFound($"No city found with the name: {city}");
            }

            City cityCords = _cityJsonProcessor.Process(cityData);

            var sunData = await _sunDataProvider.GetCurrent(cityCords.lat, cityCords.lon);

            return Ok(_sunJsonProcessor.Process(sunData));         
        }
    }
}
