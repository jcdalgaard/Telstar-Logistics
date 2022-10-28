using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;
using Microsoft.EntityFrameworkCore;
using TelstarLogistics.DbClient.Setup;

namespace DbClient.Archives
{
    public class BookingArchive: IBookingArchive
    {
        private readonly DataContext _dataContext;

        public BookingArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _dataContext.Booking.Include(b => b.Packages).Include(b => b.Routes).ThenInclude(rf=>rf.Route).ThenInclude(e=>e.FirstCity).AsEnumerable();
        }

        public IEnumerable<Booking> GetAllBookingsByUser(int userId)
        {
            return _dataContext.Booking.Include(b=>b.Packages).Include(b=>b.Routes).Where(b=>b.UserID == userId).AsEnumerable();
        }

        public bool AddBooking(Booking booking)
        {
            _dataContext.Booking.Add(booking);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
