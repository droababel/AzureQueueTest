using InvoiceProcess.Domain.Core.Entities;
using InvoiceProcess.Domain.Core.Repositories;
using InvoiceProcess.Infrasctructure.Core.Data;

namespace InvoiceProcess.Infrasctructure.Core.Repositories
{
    public sealed class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceProcessDbContext context) : base(context) { }
    }
}
