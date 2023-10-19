using InvoiceProcess.Domain.Core.Entities;
using InvoiceProcess.Domain.Core.Factories;

namespace InvoiceProcess.Infrasctructure.Core.Factories
{
    public class EntityFactory : IInvoiceFactory
    {
        public Invoice NewInvoice(
            string identification, string siteNumber, string invoiceType, string nFC,
            string issueDate, string ncfExpirationDate, string branchId, string intermediaryId,
            string intermediaryName, string invoiceNumber, string concept, string invoiceConcept,
            string policy, string transactionType, string productId, string product,
            string planTypeCode, string planTypeName, string agreementPlanId, string automaticPayment,
            string validityDateStart, string validityDateEnd, string frequencyId,
            string frequencyDescription, string invoiceExpirationDate, string invoiceAmount,
            string pendingBalance, int id = 0)
        {
            return new Invoice(
                id: id,
                identification: identification,
                siteNumber: siteNumber,
                invoiceType: invoiceType,
                nFC: nFC,
                issueDate: issueDate,
                ncfExpirationDate: ncfExpirationDate,
                branchId: branchId,
                intermediaryId: intermediaryId,
                intermediaryName: intermediaryName,
                invoiceNumber: invoiceNumber,
                concept: concept,
                invoiceConcept: invoiceConcept,
                policy: policy,
                transactionType: transactionType,
                productId: productId,
                product: product,
                planTypeCode: planTypeCode,
                planTypeName: planTypeName,
                agreementPlanId: agreementPlanId,
                automaticPayment: automaticPayment,
                validityDateStart: validityDateStart,
                validityDateEnd: validityDateEnd,
                frequencyId: frequencyId,
                frequencyDescription: frequencyDescription,
                invoiceExpirationDate: invoiceExpirationDate,
                invoiceAmount: invoiceAmount,
                pendingBalance: pendingBalance
                );
        }
    }
}
