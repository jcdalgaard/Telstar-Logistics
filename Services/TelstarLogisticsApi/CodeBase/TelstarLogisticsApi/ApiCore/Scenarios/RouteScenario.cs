using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;

namespace ApiCore.Scenarios
{
    public class RouteScenario: IRouteScenario
    {
        private readonly IBookingScenario _bookingScenario;
        private readonly ICityArchive _cityArchive;

        public RouteScenario(IBookingScenario bookingScenario, ICityArchive cityArchive)
        {
            _bookingScenario = bookingScenario;
            _cityArchive = cityArchive;
        }

        public BestRoutesDto GetRoutes()
        {
            return new BestRoutesDto()
            {
                Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = "Sahara",
                        DestinationCty = "Sahara2",
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = 123,
                        Price = 123.1,
                        Stops = 4
                    }
                },
                Fastest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = "Sahara3",
                        DestinationCty = "Sahara4",
                        EstimatedArrival = new DateTime(2022,10,20),
                        Id = 23,
                        Price = 13.1,
                        Stops = 1
                    }
                }
            };
        }

        public List<TopRouteDto> GetMostPopularRoutes()
        {
            var allBookings = _bookingScenario.GetAllBookings();
            var allRoutes = allBookings
                .SelectMany(b => b.Routes
                    .Select(rf => rf.Route))
                .Select(r=>$"{Math.Min(r.FirstCityID, r.SecondCityID)}*{Math.Max(r.FirstCityID, r.SecondCityID)}");
            var mostPopularRoutes = allRoutes.GroupBy(g => g).OrderByDescending(g => g.Count()).Take(5);
            List<TopRouteDto> result = new List<TopRouteDto>();
            foreach (var route in mostPopularRoutes)
            {
                string[] elements = route.Key.Split("*");
                City first = _cityArchive.GetById(int.Parse(elements[0]));
                City second = _cityArchive.GetById(int.Parse(elements[1]));
                result.Add(new TopRouteDto()
                {
                    City1 = first.Name,
                    City2 = second.Name
                });
            }

            return result;
        }
    }
}
