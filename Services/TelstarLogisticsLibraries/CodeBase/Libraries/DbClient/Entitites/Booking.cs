using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class Booking : BaseModel
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime BookedDate { get; set; }
        public List<BookingRouteRef> Routes { get; set; } = new List<BookingRouteRef>();
        public List<Package> Packages { get; set; } = new List<Package>();
        public User User { get; set; } = new User();
        public BookingStatus BookingStatus { get; set; } = new BookingStatus();
    }
}