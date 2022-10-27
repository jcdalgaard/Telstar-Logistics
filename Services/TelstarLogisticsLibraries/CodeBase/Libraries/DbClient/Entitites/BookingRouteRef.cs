using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class BookingRouteRef
    {
        public int BookingID { get; set; }
        public Booking Booking { get; set; } = new Booking();

        public int RouteID { get; set; }
        public Route Route { get; set; } = new Route();
    }
}