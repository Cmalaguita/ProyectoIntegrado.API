using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoIntegrado.BL.Implementations;
using ProyectoIntegrado.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoIntegrado.BL.Contracts;
namespace ProyectoIntegrado.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherForecastBL weatherForecastBL;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastBL weatherForecastBL)
        {
            _logger = logger;
            this.weatherForecastBL = weatherForecastBL;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this.weatherForecastBL.GetPrevisionesTiempo();
        }
    }
}
