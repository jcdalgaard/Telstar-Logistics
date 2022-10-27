using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; } = new User();

        public string BookingStatus { get; set; }
    }
}