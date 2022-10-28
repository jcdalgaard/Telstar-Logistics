using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TelstarLogisticsApi.Functions.Internal
{
    public class BookingFunction
    {
        private readonly IBookingScenario _bookingScenario;

        public BookingFunction(IBookingScenario bookingScenario)
        {
            _bookingScenario = bookingScenario;
        }

        [FunctionName("AddBooking")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bookings/add")]
            HttpRequest req,
            ILogger log)
        {
            try
            {
                var content = await new StreamReader(req.Body).ReadToEndAsync();

                RouteDto route = JsonConvert.DeserializeObject<RouteDto>(content);
                log.LogInformation("C# HTTP trigger function is processing a request.");
                var result = _bookingScenario.PostBooking(route);


                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult($"Error: {ex.Message}");
            }
        }

        [FunctionName("AllBookings")]
        public async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "bookings/all")]
            HttpRequest req,
            ILogger log)
        {
            try
            {

                log.LogInformation("C# HTTP trigger function is processing a request.");
                var result = _bookingScenario.GetAllBookings();

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult($"Error: {ex.Message}");
            }
        }
        [FunctionName("AllBookingsByUser")]
        public async Task<IActionResult> Run3(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "bookings/user/{userId}")] HttpRequest req, int userId,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function is processing a request.");
                var result = _bookingScenario.GetAllBookingsByUser(userId);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult($"Error: {ex.Message}");
            }
        }
    }
}
