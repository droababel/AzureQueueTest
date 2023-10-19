using InvoiceProcess.Domain.Core.Repositories;
using InvoiceProcess.Infrasctructure.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProcess.Infrasctructure.Core
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly InvoiceProcessDbContext _context;
        private bool _disposed;

        public UnitOfWork(InvoiceProcessDbContext context) => _context = context;
        public void Dispose() => Dispose(true);

        public async Task<int> Save(CancellationToken cancellationToken = default)
        {
            foreach (var entry in _context.ChangeTracker.Entries<IEntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedByAt = DateTime.UtcNow;
                        break;
                }
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
