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
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public double Price { get; set; }
        public int Stops { get; set; }
        public DateTime EstimatedArrival { get; set; }
    }
}