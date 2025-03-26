using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
    
namespace ex3
{
    public class GetSettingInfo
    {
        private readonly ILogger<GetSettingInfo> _logger;

        public GetSettingInfo(ILogger<GetSettingInfo> logger)
        {
            _logger = logger;
        }

        [Function("GetSettingInfo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, 
             [BlobInput("assets/settings.json", Connection = "AzureWebJobsStorage")] string blobContent
             )
         {
             _logger.LogInformation("C# HTTP trigger function processed a request.");
             _logger.LogInformation($"{blobContent}");

             var response = req.CreateResponse(HttpStatusCode.OK);
             response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
             await response.WriteStringAsync($"{blobContent}");

             return response;
         }
    }
}
