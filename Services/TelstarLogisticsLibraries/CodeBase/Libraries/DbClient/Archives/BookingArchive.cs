using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;
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
        public bool AddBooking(Booking booking)
        {
            _dataContext.Booking.Add(booking);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
