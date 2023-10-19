using InvoiceProccess.BackgroundJobs.InvoiceWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InvoiceProccess.BackgroundJobs.InvoiceWebService
{
    public static class InvoiceProcessEndpoint
    {
        [FunctionName("InvoiceProcessEndpoint")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SendInvoicesToProcess")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var response = new List<SendInvoiceCommandResponse>();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<List<InvoicesToSend>>(requestBody);

            foreach (var invoice in data)
            {
                var itemToResponse = new SendInvoiceCommandResponse { SiteNumber = invoice.SiteNumber, Send = true };
                response.Add(itemToResponse);
            }


            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }
    }
}
