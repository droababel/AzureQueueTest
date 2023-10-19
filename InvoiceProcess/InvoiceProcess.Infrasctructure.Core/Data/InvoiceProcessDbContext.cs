using InvoiceProcess.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace InvoiceProcess.Infrasctructure.Core.Data
{
    public class InvoiceProcessDbContext : DbContext
    {
        public InvoiceProcessDbContext(DbContextOptions<InvoiceProcessDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
