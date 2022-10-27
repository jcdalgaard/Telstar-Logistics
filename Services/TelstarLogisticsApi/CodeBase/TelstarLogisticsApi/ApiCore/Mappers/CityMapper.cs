using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using DbClient.Entitites;

namespace ApiCore.Mappers
{
    public static class CityMapper
    {
        public static List<CityNameDto> MapCityCollectionToCityNameList(IEnumerable<City> cities)
        {
            List<CityNameDto> cityNameDtos = new List<CityNameDto>();
            foreach (var city in cities)
            {
                cityNameDtos.Add(
                    new CityNameDto()
                    {
                        Name = city.Name
                    });
            }
            return cityNameDtos;
        }
    }
}
