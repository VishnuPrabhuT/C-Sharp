using System.Collections.Generic;
using VueMVC.Models;

namespace VueMVC.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
