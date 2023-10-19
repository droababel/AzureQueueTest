namespace InvoiceProcess.Domain.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
