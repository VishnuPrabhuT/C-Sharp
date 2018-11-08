using System.Collections.Generic;
using GroceryListVue.Models;

namespace GroceryListVue.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
