using AutoMapper;
using InvoiceProcess.Domain.Core.Entities;

namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Create
{
    public class CreateInvoiceCommandMapper : Profile
    {
        public CreateInvoiceCommandMapper()
        {
            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}
