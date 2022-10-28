using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Entitites;

namespace DbClient.Archives.Interfaces
{
    public interface IRouteArchive
    {
        List<Route> GetRoutesThatIncludeTheCity(
            int cityId);
    }
}
