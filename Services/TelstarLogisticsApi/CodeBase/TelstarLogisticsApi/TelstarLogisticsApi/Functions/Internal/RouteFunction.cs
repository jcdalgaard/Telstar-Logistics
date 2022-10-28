using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Scenarios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace TelstarLogisticsApi.Functions.Internal
{
    public class RouteFunction
    {

        private readonly IRouteScenario _routeScenario;

        public RouteFunction(IRouteScenario routeScenario)
        {
            _routeScenario = routeScenario;
        }

        [FunctionName("SearchRoute")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SearchRoute")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string departureCityString = req.Query["departureCity"];
                string destinationCityString = req.Query["destinationCity"];
                if (string.IsNullOrEmpty(departureCityString))
                {
                    throw new ArgumentException("The departure city parameter is null or empty");
                }

                if (string.IsNullOrEmpty(destinationCityString))
                {
                    throw new ArgumentException("The destination city parameter is null or empty");
                }
                log.LogInformation("C# HTTP trigger function processed a request.");
                var result = _routeScenario.GetRoutes(departureCityString, destinationCityString);

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
