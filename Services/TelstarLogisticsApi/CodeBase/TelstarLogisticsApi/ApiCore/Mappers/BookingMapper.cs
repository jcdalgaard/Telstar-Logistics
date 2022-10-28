using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using DbClient.Entitites;

namespace ApiCore.Mappers
{
    public static class BookingMapper
    {
        public static Booking MapRouteDtoToBooking(RouteDto routeDto)
        {
            return new Booking()
            {
                ID = routeDto.Id,
                ArrivalDate = routeDto.EstimatedArrival,
                BookedDate = DateTime.Now,
                Price = routeDto.Price
            };
        }
    }
}
