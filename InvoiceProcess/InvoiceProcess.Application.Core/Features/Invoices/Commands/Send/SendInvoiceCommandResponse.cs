namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Send
{
    public class SendInvoiceCommandResponse
    {
        public string SiteNumber { get; set; } = string.Empty;
        public bool Send { get; set; }
    }
}
