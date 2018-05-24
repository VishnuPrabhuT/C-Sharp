using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<CityModel> Cities { get; set; }
        public CityDataStore()
        {
            Cities = new List<CityModel>()
            {
                new CityModel()
                {
                     Id = 1,
                     Name = "New York City",
                     Description = "The one with that big park.",
                     PointOfInterest = new List<PointOfInterestModel>()
                     {
                         new PointOfInterestModel() {
                             Id = 1,
                             Name = "Central Park",
                             Description = "The most visited urban park in the United States." },
                          new PointOfInterestModel() {
                             Id = 2,
                             Name = "Empire State Building",
                             Description = "A 102-story skyscraper located in Midtown Manhattan." },
                     }
                },
                new CityModel()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointOfInterest = new List<PointOfInterestModel>()
                     {
                         new PointOfInterestModel() {
                             Id = 3,
                             Name = "Cathedral of Our Lady",
                             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans." },
                          new PointOfInterestModel() {
                             Id = 4,
                             Name = "Antwerp Central Station",
                             Description = "The the finest example of railway architecture in Belgium." },
                     }
                },
                new CityModel()
                {
                    Id= 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointOfInterest = new List<PointOfInterestModel>()
                     {
                         new PointOfInterestModel() {
                             Id = 5,
                             Name = "Eiffel Tower",
                             Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                          new PointOfInterestModel() {
                             Id = 6,
                             Name = "The Louvre",
                             Description = "The world's largest museum." },
                     }
                }
            };
        }
    }
}
