using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;

namespace ApiCore.Scenarios
{
    public class RouteScenario: IRouteScenario
    {
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
            };
        }
    }
}
