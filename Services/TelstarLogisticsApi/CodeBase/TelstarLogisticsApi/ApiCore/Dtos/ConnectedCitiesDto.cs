using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos
{
    public class ConnectedCitiesDto
    {
        public string Provider { get; set; }
        public List<CityDto> ConnectedCities { get; set; }
    }
}
