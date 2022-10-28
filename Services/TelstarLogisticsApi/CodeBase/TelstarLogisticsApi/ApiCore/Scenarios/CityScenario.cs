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
using Microsoft.EntityFrameworkCore.Query;

namespace ApiCore.Scenarios
{
    public class CityScenario : ICityScenario
    {
        private readonly ICityArchive _cityArchive;
        private readonly IRouteArchive _routeArchive;
        private readonly ISegmentPriceArchive _segmentPriceArchive;
        private readonly IBookingArchive _bookingArchive;

        public CityScenario(ICityArchive cityArchive, IRouteArchive routeArchive, ISegmentPriceArchive segmentPriceArchive, IBookingArchive bookingArchive)
        {
            _cityArchive = cityArchive;
            _routeArchive = routeArchive;
            _segmentPriceArchive = segmentPriceArchive;
            _bookingArchive = bookingArchive;
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

        public List<TopPopularCityDto> GetMostPopularCities()
        {
            var allRoutes = _bookingArchive.GetAllBookings().SelectMany(b => b.Routes.Select(rf => rf.Route));
            var groups = allRoutes.Select(r => r.FirstCityID).Concat(allRoutes.Select(r => r.SecondCityID)).GroupBy(i => i);
            return groups.OrderByDescending(g => g.Count()).Take(5).Select(c => CityMapper.MapCityToTopPopularCityDto(_cityArchive.GetById(c.Key), c.Count())).ToList();
        }

        public List<TopPriceCityDto> GetMostExpensiveCities()
        {
            var allBookings = _bookingArchive.GetAllBookings();
            Dictionary<string, double> cityValues = new Dictionary<string, double>();
            foreach (var booking in allBookings)
            {
                var endCities = GetBookingEndCities(booking);
                foreach (var city in endCities)
                {
                    if (!cityValues.ContainsKey(city.ID.ToString()))
                    {
                        cityValues.Add(city.ID.ToString(), booking.Price);
                    }
                    else
                    {
                        cityValues[city.ID.ToString()] += booking.Price;
                    }
                }

            }
            return cityValues.OrderByDescending(d => d.Value).Take(5).Select(c => CityMapper.MapCityToTopPriceCityDto(_cityArchive.GetById(int.Parse(c.Key)), c.Value)).ToList();
        }



        private List<City> GetBookingEndCities(Booking booking)
        {
            var allRoutes = booking.Routes.Select(r=>r.Route).ToList();
            var groups =  allRoutes.Select(r => r.FirstCityID).Concat(allRoutes.Select(r => r.SecondCityID)).GroupBy(i => i);
            return groups.Where(g => g.Count() % 2 == 1).Take(2).Select(g=>_cityArchive.GetById(g.Key)).ToList();

        }
    }
}