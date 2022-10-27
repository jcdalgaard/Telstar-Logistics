using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Entitites;
using TelstarLogistics.DbClient.Setup;

namespace DbClient.Archives.Interfaces
{
    public interface ICityArchive
    {
        IEnumerable<City> GetAllCities();
    }
}
