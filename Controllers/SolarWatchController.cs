using Microsoft.AspNetCore.Mvc;
using SolarWatch.Service.CityDataProvider;
using SolarWatch.Service.CityJsonProcessor;
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
        public SolarWatchController(ILogger<SolarWatchController> logger, ICityDataProvider cityDataProvider, ICityJsonProcessor cityJsonProcessor)
        {
            _logger = logger;
            _cityDataProvider = cityDataProvider;
            _cityJsonProcessor = cityJsonProcessor;
        }

        [HttpGet("Get")]
        public IActionResult Get([Required] string city)
        {
            var cityData = _cityDataProvider.GetCurrent(city);

            if(cityData == "[]") 
            {
                return NotFound($"No city found with the name: {city}");
            }

            return Ok(_cityJsonProcessor.Process(cityData));
        }
    }
}
