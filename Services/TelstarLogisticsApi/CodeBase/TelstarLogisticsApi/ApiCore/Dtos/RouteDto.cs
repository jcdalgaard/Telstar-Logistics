using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos
{
    public class RouteDto
    {
        public string Id { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCty { get; set; }
        public double Price { get; set; }
        public int Stops { get; set; }
        public DateOnly EstimatedArrival { get; set; }
    }
}
