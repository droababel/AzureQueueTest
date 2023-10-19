using MediatR;

namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Send
{
    public class SendInvoiceCommand : IRequest<List<SendInvoiceCommandResponse>>
    {
        public List<InvoicesToSend> InvoicesToSend { get; set; } = new List<InvoicesToSend>();
    }

    public class InvoicesToSend 
    {
        public string Identification { get; set; } = string.Empty;
        public string SiteNumber { get; set; } = string.Empty;
        public string InvoiceType { get; set; } = string.Empty;
        public string NCF { get; set; } = string.Empty;
        public string IssueDate { get; set; } = string.Empty;
        public string NcfExpirationDate { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string IntermediaryId { get; set; } = string.Empty;
        public string IntermediaryName { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public string InvoiceConcept { get; set; } = string.Empty;
        public string Policy { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string PlanTypeCode { get; set; } = string.Empty;
        public string PlanTypeName { get; set; } = string.Empty;
        public string AgreementPlanId { get; set; } = string.Empty;
        public string AutomaticPayment { get; set; } = string.Empty;
        public string ValidityDateStart { get; set; } = string.Empty;
        public string ValidityDateEnd { get; set; } = string.Empty;
        public string FrequencyId { get; set; } = string.Empty;
        public string FrequencyDescription { get; set; } = string.Empty;
        public string InvoiceExpirationDate { get; set; } = string.Empty;
        public string InvoiceAmount { get; set; } = string.Empty;
        public string PendingBalance { get; set; } = string.Empty;
    }
}
