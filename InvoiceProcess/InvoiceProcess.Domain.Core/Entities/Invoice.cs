using InvoiceProcess.Domain.Core.Repositories;

namespace InvoiceProcess.Domain.Core.Entities
{
    public class Invoice : IEntityBase
    {
        public Invoice() { }
        public Invoice(
            int id, string identification, string siteNumber, string invoiceType, string nFC,
            string issueDate, string ncfExpirationDate, string branchId, string intermediaryId,
            string intermediaryName, string invoiceNumber, string concept, string invoiceConcept,
            string policy, string transactionType, string productId, string product, string planTypeCode,
            string planTypeName, string agreementPlanId, string automaticPayment, string validityDateStart,
            string validityDateEnd, string frequencyId, string frequencyDescription, string invoiceExpirationDate,
            string invoiceAmount, string pendingBalance)
        {
            Id = id;
            Identification = identification;
            SiteNumber = siteNumber;
            InvoiceType = invoiceType;
            NCF = nFC;
            IssueDate = issueDate;
            NcfExpirationDate = ncfExpirationDate;
            BranchId = branchId;
            IntermediaryId = intermediaryId;
            IntermediaryName = intermediaryName;
            InvoiceNumber = invoiceNumber;
            Concept = concept;
            InvoiceConcept = invoiceConcept;
            Policy = policy;
            TransactionType = transactionType;
            ProductId = productId;
            Product = product;
            PlanTypeCode = planTypeCode;
            PlanTypeName = planTypeName;
            AgreementPlanId = agreementPlanId;
            AutomaticPayment = automaticPayment;
            ValidityDateStart = validityDateStart;
            ValidityDateEnd = validityDateEnd;
            FrequencyId = frequencyId;
            FrequencyDescription = frequencyDescription;
            InvoiceExpirationDate = invoiceExpirationDate;
            InvoiceAmount = invoiceAmount;
            PendingBalance = pendingBalance;
        }

        public int Id { get; set; }
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
