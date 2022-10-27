using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos
{
    public class BestRoutesDto
    {
        public List<RouteDto> Cheapest { get; set; }
        public List<RouteDto> Fastest { get; set; }
    }
}
