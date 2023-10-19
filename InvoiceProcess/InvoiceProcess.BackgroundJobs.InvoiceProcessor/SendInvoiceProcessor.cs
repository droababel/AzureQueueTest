using InvoiceProcess.Application.Core.Features.Invoices.Commands.Send;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceProcess.BackgroundJobs.InvoiceProcessor
{
    public class SendInvoiceProcessor
    {
        private readonly IMediator _mediator;

        public SendInvoiceProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("SendInvoiceProcessor")]
        public async Task Run([QueueTrigger("send-invoice", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"New message incoming {myQueueItem}");
            log.LogInformation("Processing...");

            var invoicesSend = await _mediator.Send(new SendInvoiceCommand());

            log.LogInformation($"Invoices send: {JsonSerializer.Serialize(invoicesSend)}");
        }
    }
}
