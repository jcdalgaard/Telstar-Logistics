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
    public class RouteArchive : IRouteArchive
    {
        private readonly DataContext _dataContext;

        public RouteArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Route> GetRoutesThatIncludeTheCity(
            int cityId)
        {
            return _dataContext.Route.Where(x => x.FirstCityID == cityId || x.SecondCityID == cityId).ToList();
        }
    }
}
