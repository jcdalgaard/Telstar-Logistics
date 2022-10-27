using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ApiCore.Scenarios.Interfaces;

namespace TelstarLogisticsApi
{
    public class Cities
    {
        private readonly ICityScenario _cityScenario;

        public Cities(ICityScenario cityScenario)
        {
            _cityScenario = cityScenario;
        }

        [FunctionName("GetConnectedCities")]
        public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetConnectedCities/{cityName}")] HttpRequest req, string cityName,
    ILogger log)
        {
            try
            {
                string weightString = req.Query["weight"];
                string contentType = req.Query["contentType"];
                if (string.IsNullOrEmpty(weightString))
                {
                    throw new ArgumentException("The weight parameter is null or empty");
                }

                if (string.IsNullOrEmpty(contentType))
                {
                    throw new ArgumentException("The content type parameter is null or empty");
                }
                double weight = double.Parse(weightString);
                log.LogInformation("C# HTTP trigger function processed a request.");
                var result = _cityScenario.GetConnectedCities(cityName, weight, contentType);

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
