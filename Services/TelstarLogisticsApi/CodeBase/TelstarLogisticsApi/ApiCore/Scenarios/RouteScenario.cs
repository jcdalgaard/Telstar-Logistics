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

        public RouteScenario(ICalculateRouteArchive calculateRouteArchive)
        {
            _calculateRouteArchive = calculateRouteArchive;
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
                        Id = "-1", // maybe remove
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
                        Id = "-1", // maybe remove
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
                        Id = "23", // maybe remove
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
                        Id = "23", // maybe remove
                        Price = fastestRoute.SegmentPrice.Value * fastestRoute.NumberOfSegments,
                        Stops = fastestRoute.NumberOfSegments
                    }
                }
            };
        }
    }
}