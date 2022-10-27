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

        public BestRoutesDto GetRoutes()
        {
            /*return new BestRoutesDto()
            {
                Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = "Sahara",
                        DestinationCty = "Sahara2",
                        EstimatedArrival = new DateOnly(2022,10,28),
                        Id = "213",
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
                        EstimatedArrival = new DateOnly(2022,10,20),
                        Id = "23",
                        Price = 13.1,
                        Stops = 1
                    }
                }
            */
            List<Route> AllRoutes = _calculateRouteArchive.GetAllRoutes();
            CalculateRoute cr = new CalculateRoute();
            int start = 22;
            int end = 5;
            Route cheapestRoute = cr.calculateCheapestRoute(AllRoutes, start, end);
            //Route fastestRoute =
            return new BestRoutesDto()
            {
                Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = cheapestRoute.FirstCity.Name,
                        DestinationCty = cheapestRoute.SecondCity.Name,
                        EstimatedArrival = new DateOnly(2022,10,20),
                        Id = "23", // maybe remove
                        Price = cheapestRoute.SegmentPrice.Value * cheapestRoute.NumberOfSegments,
                        Stops = cheapestRoute.NumberOfSegments
                    }
                },

                Fastest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = "Sahara3",
                        DestinationCty = "Sahara4",
                        EstimatedArrival = new DateOnly(2022,10,20),
                        Id = "23",
                        Price = 13.1,
                        Stops = 1
                    }
                }
            };
        }
    }
}
