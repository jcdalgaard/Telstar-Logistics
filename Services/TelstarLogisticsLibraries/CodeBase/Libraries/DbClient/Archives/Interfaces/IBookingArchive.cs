using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Entitites;

namespace DbClient.Archives.Interfaces
{
    public interface IBookingArchive
    {
        bool AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetAllBookingsByUser(int userId);
    }
}
