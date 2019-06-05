using System.Collections.Generic;
using VueTemplate.Models;

namespace VueTemplate.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
