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
    public class CityArchive: ICityArchive
    {
        private readonly DataContext _dataContext;

        public CityArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _dataContext.City.AsEnumerable();
        }
    }
}
