using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Mappers;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;


namespace ApiCore.Scenarios
{
    public class CityScenario : ICityScenario
    {
        private readonly ICityArchive _cityArchive;
        private readonly IRouteArchive _routeArchive;
        private readonly ISegmentPriceArchive _segmentPriceArchive;

        public CityScenario(ICityArchive cityArchive, IRouteArchive routeArchive, ISegmentPriceArchive segmentPriceArchive)
        {
            _cityArchive = cityArchive;
            _routeArchive = routeArchive;
            _segmentPriceArchive = segmentPriceArchive;
        }

        public ConnectedCitiesDto GetConnectedCities(string cityName, double weight, string contentType)
        {
            if (contentType.ToLower() == "weapons" || weight > 40 * 1000)
            {
                return new ConnectedCitiesDto();
            }

            var id = _cityArchive.GetIdByName(cityName);
            var routesContainCity = _routeArchive.GetRoutesThatIncludeTheCity(id);
            var adjacentCities = new HashSet<CityDto>();
            foreach (var route in routesContainCity)
            {
                var city1 = _cityArchive.GetById(route.FirstCityID);
                var city2 = _cityArchive.GetById(route.SecondCityID);

                var routePrice = _segmentPriceArchive.GetById(route.SegmentPriceID).Value * route.NumberOfSegments;
                var adjacent = new CityDto
                {
                    Price = routePrice,
                    Duration = route.Duration,
                };
   
                adjacent.CityName = (city1.ID != id) ? city1.Name : city2.Name;
                adjacentCities.Add(adjacent);
            }

            return new ConnectedCitiesDto
            {
                Provider = "",
                ConnectedCities = adjacentCities.ToList(),
            };
        }

        public List<CityNameDto> GetAllCities()
        {
            return CityMapper.MapCityCollectionToCityNameList(_cityArchive.GetAllCities());
        }
    }
}