using ProyectoIntegrado.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IWeatherForecastBL
    {
        public IEnumerable<WeatherForecast> GetPrevisionesTiempo();
    }
}
