using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Mappers;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;

namespace ApiCore.Scenarios
{
    public class BookingScenario: IBookingScenario
    {
        private readonly IBookingArchive _bookingArchive;

        public BookingScenario(IBookingArchive bookingArchive)
        {
            _bookingArchive = bookingArchive;
        }
        public bool PostBooking(RouteDto routeDto)
        {
            return _bookingArchive.AddBooking(BookingMapper.MapRouteDtoToBooking(routeDto));
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingArchive.GetAllBookings().ToList();
        }

        public List<Booking> GetAllBookingsByUser(int userId)
        {
            return _bookingArchive.GetAllBookingsByUser(userId).ToList();
        }
    }
}
