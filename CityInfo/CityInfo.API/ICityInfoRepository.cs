using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePOI);
        IEnumerable<PointsOfInterest> GetPointsOfInterest(int cityId);
        PointsOfInterest GetPointOfInterest(int cityId, int id);
    }
}
