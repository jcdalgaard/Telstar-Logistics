using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using DbClient.Entitites;

namespace ApiCore.Scenarios.Interfaces
{
    public interface IBookingScenario
    {
        bool PostBooking(RouteDto routeDto);

        List<Booking> GetAllBookings();
        List<Booking> GetAllBookingsByUser(int userId);
    }
}
