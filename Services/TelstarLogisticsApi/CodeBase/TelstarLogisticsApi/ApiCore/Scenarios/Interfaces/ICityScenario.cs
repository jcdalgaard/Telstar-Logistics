using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;

namespace ApiCore.Scenarios.Interfaces
{
    public interface ICityScenario
    {
        public ConnectedCitiesDto GetConnectedCities(string cityName, double weight, string contentType);
        public List<CityNameDto> GetAllCities();
    }
}
