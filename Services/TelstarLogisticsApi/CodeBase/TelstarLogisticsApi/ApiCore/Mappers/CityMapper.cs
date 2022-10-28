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

        public static List<TopPriceCityDto> MapCityCollectionToTopCityDtoList(IEnumerable<City> cities)
        {
            List<TopPriceCityDto> topCityDtos = new List<TopPriceCityDto>();
            foreach (var city in cities)
            {
                topCityDtos.Add(
                    new TopPriceCityDto()
                    {
                        Id = city.ID,
                        Name = city.Name
                    });
            }

            return topCityDtos;
        }

        public static TopPriceCityDto MapCityToTopPriceCityDto(City city, double price)
        {
            return new TopPriceCityDto()
            {
                Id = city.ID,
                Name = city.Name,
                Value = price
            };
        }
        public static TopPopularCityDto MapCityToTopPopularCityDto(City city, int value)
        {
            return new TopPopularCityDto()
            {
                Id = city.ID,
                Name = city.Name,
                Value = value
            };
        }
    }
}
