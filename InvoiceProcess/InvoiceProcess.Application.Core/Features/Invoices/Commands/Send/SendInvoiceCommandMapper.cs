using AutoMapper;
using InvoiceProcess.Domain.Core.Entities;

namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Send
{
    public class SendInvoiceCommandMapper : Profile
    {
        public SendInvoiceCommandMapper()
        {
            CreateMap<Invoice, SendInvoiceCommandResponse>();
            CreateMap<SendInvoiceCommandResponse, Invoice>();
            CreateMap<Invoice, InvoicesToSend>();
        }
    }
}
