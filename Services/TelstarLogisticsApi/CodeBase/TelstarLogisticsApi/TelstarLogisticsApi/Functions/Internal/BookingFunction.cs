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

        [FunctionName("Bookings")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Bookings")]
            HttpRequest req,
            ILogger log)
        {
            try
            {
                var content = await new StreamReader(req.Body).ReadToEndAsync();

                RouteDto route = JsonConvert.DeserializeObject<RouteDto>(content);
                log.LogInformation("C# HTTP trigger function processed a request.");
                var result = _bookingScenario.PostBooking(route);

                string responseMessage = $"Hello! This HTTP triggered function executed successfully.";

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult($"Error: {ex.Message}");
            }
        }
    }
}
