using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public int GetIdByName(string cityName)
        {
            var city = _dataContext.City.FirstOrDefault(x => x.Name == cityName.ToLower());
            if (city == null)
            {
                throw new HttpRequestException("Bad Request");
            }

            return city.ID;
        }

        public City GetById(
            int id)
        {
            var city = _dataContext.City.FirstOrDefault(x => x.ID == id);
            if (city == null)
            {
                throw new HttpRequestException("City Not Found");
            }

            return city;
        }
    }
}
