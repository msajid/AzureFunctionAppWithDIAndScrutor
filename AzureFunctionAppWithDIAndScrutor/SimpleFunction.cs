using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionAppWithDIAndScrutor
{
    public class SimpleFunction
    {
        private readonly ISomeService service;

        public SimpleFunction(ISomeService service)
        {
            this.service = service;
        }

        [FunctionName("SimpleFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            service.DoSomething();
            return new OkObjectResult(new { hello = "injection"});
        }
    }
}
