using AutoMapper;
using InvoiceProcess.Domain.Core.Entities;
using InvoiceProcess.Domain.Core.Repositories;
using MediatR;

namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Create
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            await CreateInvoiceAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private async Task CreateInvoiceAsync(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var newInvoice = _mapper.Map<Invoice>(command);
            await _invoiceRepository.AddAsync(newInvoice);
            await _unitOfWork.Save(cancellationToken);
        }

    }
}
