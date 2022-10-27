using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;

namespace ApiCore.Scenarios.Interfaces
{
    public interface IBookingScenario
    {
        bool PostBooking(RouteDto routeDto);
    }
}
