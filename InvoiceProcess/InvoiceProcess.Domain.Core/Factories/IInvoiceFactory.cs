using InvoiceProcess.Domain.Core.Entities;

namespace InvoiceProcess.Domain.Core.Factories
{
    public interface IInvoiceFactory
    {
        Invoice NewInvoice(
            string identification, string siteNumber, string invoiceType, string nFC,
            string issueDate, string ncfExpirationDate, string branchId, string intermediaryId,
            string intermediaryName, string invoiceNumber, string concept, string invoiceConcept,
            string policy, string transactionType, string productId, string product, string planTypeCode,
            string planTypeName, string agreementPlanId, string automaticPayment, string validityDateStart,
            string validityDateEnd, string frequencyId, string frequencyDescription, string invoiceExpirationDate,
            string invoiceAmount, string pendingBalance, int id = 0
            );
    }
}
