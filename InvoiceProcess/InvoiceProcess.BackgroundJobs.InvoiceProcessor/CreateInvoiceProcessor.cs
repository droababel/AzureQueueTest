using InvoiceProcess.Application.Core.Common.Messages.Invoice;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceProcess.BackgroundJobs.InvoiceProcessor
{
    public class CreateInvoiceProcessor
    {
        private readonly IMediator _mediator;

        public CreateInvoiceProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("CreateInvoiceProcessor")]
        public async Task Run([QueueTrigger("create-new-invoice", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"New message incoming {myQueueItem}");
            log.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<CreateInvoiceMessage>(myQueueItem);

            await _mediator.Send(message.CreateInvoiceCommand);

            log.LogInformation("Invoice Created!");
        }
    }
}
