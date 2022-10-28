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
using DbClient;

namespace ApiCore.Scenarios
{
    public class RouteScenario: IRouteScenario
    {
        private readonly ICalculateRouteArchive _calculateRouteArchive;
        private readonly IBookingScenario _bookingScenario;
        private readonly ICityArchive _cityArchive;

        public RouteScenario(ICalculateRouteArchive calculateRouteArchive, IBookingScenario bookingScenario, ICityArchive cityArchive)
        {
            _calculateRouteArchive = calculateRouteArchive;
            _bookingScenario = bookingScenario;
            _cityArchive = cityArchive;
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

        public BestRoutesDto GetRoutes(string from, string to)
        {
            List<Route> AllRoutes = _calculateRouteArchive.GetAllRoutes();
            int start = _calculateRouteArchive.GetCityID(from);
            int end = _calculateRouteArchive.GetCityID(to);
            CalculateRoute cr = new CalculateRoute();
            Route cheapestRoute = cr.calculateCheapestRoute(AllRoutes, start, end);
            Route fastestRoute = cr.calculateFastestRoute(AllRoutes, start, end);

            if (cheapestRoute.SegmentPrice.Value * cheapestRoute.NumberOfSegments > 100000)
            {
                return new BestRoutesDto()
                {
                    Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = from,
                        DestinationCty = to,
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = -1, // maybe remove
                        Price = 0,
                        Stops = -1
                    }
                },

                    Fastest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = from,
                        DestinationCty = to,
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = -1, // maybe remove
                        Price = 0,
                        Stops = -1
                    }
                }
                };
            } 
            return new BestRoutesDto()
            {
                Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = from,
                        DestinationCty = to,
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = 23, // maybe remove
                        Price = cheapestRoute.SegmentPrice.Value * cheapestRoute.NumberOfSegments,
                        Stops = cheapestRoute.NumberOfSegments
                    }
                },

                Fastest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = from,
                        DestinationCty = to,
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = 23, // maybe remove
                        Price = fastestRoute.SegmentPrice.Value * fastestRoute.NumberOfSegments,
                        Stops = fastestRoute.NumberOfSegments
                    }
                }
            };
        }
    }
}
