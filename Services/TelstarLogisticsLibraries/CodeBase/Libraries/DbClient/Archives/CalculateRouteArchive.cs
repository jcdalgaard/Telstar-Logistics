using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;
using TelstarLogistics.DbClient.Setup;

namespace DbClient.Archives
{
    public class CalculateRouteArchive : ICalculateRouteArchive
    {
        private readonly DataContext _dataContext;

        public CalculateRouteArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Route> GetAllRoutes()
        {
            return _dataContext.Route.ToList();
        }

        public int GetCityID(string city)
        {
            return _dataContext.City.Where(x => x.Name == city).Select(x => x.ID).Single();
        }

        public List<Route> SetRoutesPrices(List<Route> AllRoutes)
        {
            foreach (var route in AllRoutes)
            {
                route.SegmentPrice.Value = _dataContext.SegmentPrice.Where(x => x.ID == route.SegmentPriceID).Select(x => x.Value).Single();
            }

            return AllRoutes;
        }
    }
}