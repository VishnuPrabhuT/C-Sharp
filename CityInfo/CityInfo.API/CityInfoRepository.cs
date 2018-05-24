using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _cxt;
        public CityInfoRepository(CityInfoContext cxt)
        {
            _cxt = cxt;
        }
        public IEnumerable<City> GetCities()
        {
            return _cxt.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePOI = false)
        {
            if (includePOI)
            {
                return _cxt.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }
            return _cxt.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointsOfInterest GetPointOfInterest(int cityId, int Id)
        {
            return _cxt.PointsOfInterest.Where(c => c.CityId == cityId && c.Id == Id).FirstOrDefault();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterest(int cityId)
        {
            return _cxt.PointsOfInterest.Where(c => c.CityId == cityId).ToList();
        }
    }
}
