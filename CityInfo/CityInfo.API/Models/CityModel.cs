using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointOfInterest
        {
            get
            {
                return PointOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestModel> PointOfInterest = new List<PointOfInterestModel>();
    }
}
