using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;

namespace ApiCore.Scenarios
{
    public class CityScenario: ICityScenario
    {
        public ConnectedCitiesDto GetConnectedCities(string cityName, double weight, string contentType)
        {
            return new ConnectedCitiesDto()
            {
                Provider = "TELSTAR THE WINNER OF CES 24.10.2022",
                ConnectedCities = new List<CityDto>()
                {
                    new CityDto()
                    {
                        CityName = "Sahara",
                        Price = 123.1723,
                        Duration = 51
                    },
                    new CityDto()
                    {
                        CityName = "Hvalbugten",
                        Price = 53.1723,
                        Duration = 16
                    },
                }
            };
        }

        public List<CityNameDto> GetAllCities()
        {
            return new List<CityNameDto>()
            {
                new CityNameDto()
                {
                    Name = "Sahara"
                },
                new CityNameDto()
                {
                    Name = "Hvalbugten"
                }
            };
        }
    }
}
