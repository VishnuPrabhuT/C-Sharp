using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Entities;
using CityInfo.API.Services;
using CityInfo.API.Models;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CityController : Controller
    {
        private CityInfoContext _cic;
        private LocalMailService _localMailService;
        private ICityInfoRepository _cir;

        public CityController(CityInfoContext cic, LocalMailService localMailService, ICityInfoRepository cir)
        {
            _cic = cic;
            _cir = cir;
            _localMailService = localMailService;
        }
        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntities = _cir.GetCities();
            var results = new List<CityWithoutPOI>();
            foreach(var cityInfo in cityEntities)
            {
                results.Add(new CityWithoutPOI
                {
                    Id = cityInfo.Id,
                    Name = cityInfo.Name,
                    Description = cityInfo.Description
                });
            }
            return Ok(results);
            //return Ok(CityDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(city => city.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("testdatabase")]
        public IActionResult testDB()
        {
            _localMailService.Send("DB was created or migrated!", "From Test DB Action!");
            return Ok();
        }
    }
}

