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
                var content = await new StreamReader(req.Body).ReadToEndAsync();
                SearchDto searchDto = JsonConvert.DeserializeObject<SearchDto>(content);
                if (searchDto is null)
                {
                    throw new ArgumentException("There are no parameters.");
                }
                if (string.IsNullOrEmpty(searchDto.DepartureCity))
                {
                    throw new ArgumentException("The departure city parameter is null or empty");
                }

                if (string.IsNullOrEmpty(searchDto.DestinationCity))
                {
                    throw new ArgumentException("The destination city parameter is null or empty");
                }
                log.LogInformation("C# HTTP trigger function processed a request.");
                var result = _routeScenario.GetRoutes(searchDto);

                _routeScenario.ApplyFees(result, searchDto);
                string responseMessage = $"Hello! This HTTP triggered function executed successfully.";

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult($"Error: {ex.Message}");
            }
        }

        [FunctionName("MostPopularRoute")]
        public async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "route/mostPopular")] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                var result = _routeScenario.GetMostPopularRoutes();

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
