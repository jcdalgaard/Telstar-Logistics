using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;
using DbClient;

namespace ApiCore.Scenarios
{
    public class RouteScenario : IRouteScenario
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
                    .Select(rf => rf.Route));
            var groups = allRoutes.GroupBy(x => new
                {
                    x.FirstCityID,
                    x.SecondCityID,
                    x.Duration
                });
            var result = groups.OrderByDescending(g => g.Count()).Take(5).Select(r =>
            {
                City first = _cityArchive.GetById(r.Key.FirstCityID);
                City second = _cityArchive.GetById(r.Key.SecondCityID);
                return new TopRouteDto()
                {
                    City1 = first.Name,
                    City2 = second.Name,
                    Total = r.Count(),
                    ThisMonth = r.Sum(g => g.Duration)

                };
            }).ToList();

            return result;
        }

        public BestRoutesDto GetRoutes(SearchDto searchDto)
        {
            List<Route> AllRoutes = _calculateRouteArchive.GetAllRoutes();
            List<Route> AllRoutesWithPrices = _calculateRouteArchive.SetRoutesPrices(AllRoutes);
            int start = _calculateRouteArchive.GetCityID(from);
            int end = _calculateRouteArchive.GetCityID(to);
            CalculateRoute cr = new CalculateRoute();
            Route cheapestRoute = cr.calculateCheapestRoute(AllRoutesWithPrices, start, end);
            Route fastestRoute = cr.calculateFastestRoute(AllRoutesWithPrices, start, end);

            if (cheapestRoute.SegmentPrice.Value * cheapestRoute.NumberOfSegments > 100000)
            {
                return new BestRoutesDto()
                {
                    Cheapest = new List<RouteDto>()
                {
                    new RouteDto()
                    {
                        DepartureCity = searchDto.DepartureCity,
                        DestinationCty = searchDto.DestinationCity,
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
                        DepartureCity = searchDto.DepartureCity,
                        DestinationCty = searchDto.DestinationCity,
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
                        DepartureCity = searchDto.DepartureCity,
                        DestinationCty = searchDto.DestinationCity,
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
                        DepartureCity = searchDto.DepartureCity,
                        DestinationCty = searchDto.DestinationCity,
                        EstimatedArrival = new DateTime(2022,10,28),
                        Id = 23, // maybe remove
                        Price = fastestRoute.SegmentPrice.Value * fastestRoute.NumberOfSegments,
                        Stops = fastestRoute.NumberOfSegments
                    }
                }
            };
        }

        public void ApplyFees(BestRoutesDto bestRoutesDto, SearchDto searchDto)
        {
            if (searchDto.CautiousParcels)
            {
                foreach (var elem in bestRoutesDto.Cheapest)
                {
                    elem.Price *= 0.75;
                }

                foreach (var elem in bestRoutesDto.Fastest)
                {
                    elem.Price *= 0.75;
                }
            }
            if (searchDto.LiveAnimals)
            {
                foreach (var elem in bestRoutesDto.Cheapest)
                {
                    elem.Price *= 0.5;
                }

                foreach (var elem in bestRoutesDto.Fastest)
                {
                    elem.Price *= 0.5;
                }
            }
            if (searchDto.RecordedDelivery)
            {
                foreach (var elem in bestRoutesDto.Cheapest)
                {
                    elem.Price += 10;
                }

                foreach (var elem in bestRoutesDto.Fastest)
                {
                    elem.Price += 10;
                }
            }
            if (searchDto.RefridgeratedGoods)
            {
                foreach (var elem in bestRoutesDto.Cheapest)
                {
                    elem.Price *= 0.1;
                }

                foreach (var elem in bestRoutesDto.Fastest)
                {
                    elem.Price *= 0.1;
                }
            }
        }
    }
}
