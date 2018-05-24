using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        [HttpGet("{cityid}/pointofinterest")]
        public IActionResult GetPointOfInterest(int cityid)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => cityid == x.Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{cityid}/pointofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityid, int id)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => cityid == x.Id);
            if (result == null)
            {
                return NotFound();
            }

            var resultPOI = result.PointOfInterest.FirstOrDefault(x => id == x.Id);
            if (resultPOI == null)
            {
                return NotFound();
            }
            return Ok(resultPOI);
        }

        
    }
}
