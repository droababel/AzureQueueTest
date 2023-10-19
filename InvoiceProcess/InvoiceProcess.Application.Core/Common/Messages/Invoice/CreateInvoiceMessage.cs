using InvoiceProcess.Application.Core.Features.Invoices.Commands.Create;

namespace InvoiceProcess.Application.Core.Common.Messages.Invoice
{
    public class CreateInvoiceMessage
    {
        public CreateInvoiceCommand CreateInvoiceCommand { get; set; } = default!;
    }
}
