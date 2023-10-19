namespace InvoiceProccess.BackgroundJobs.InvoiceWebService.Models
{
    public class SendInvoiceCommandResponse
    {
        public string SiteNumber { get; set; } = string.Empty;
        public bool Send { get; set; }
    }
}
