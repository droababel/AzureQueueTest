using AutoMapper;
using InvoiceProcess.Domain.Core.Repositories;
using InvoiceProcess.Infrasctructure.Core.Services.RequestHandler;
using MediatR;
using Newtonsoft.Json;

namespace InvoiceProcess.Application.Core.Features.Invoices.Commands.Send
{
    public class SendInvoiceCommandHandler : IRequestHandler<SendInvoiceCommand, List<SendInvoiceCommandResponse>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly HttpRequestService _httpRequestService;

        public SendInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, HttpRequestService httpRequestService)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
        }

        public async Task<List<SendInvoiceCommandResponse>> Handle(SendInvoiceCommand request, CancellationToken cancellationToken)
        {
            return await SendInvoiceAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private async Task<List<SendInvoiceCommandResponse>> SendInvoiceAsync(SendInvoiceCommand command, CancellationToken cancellationToken)
        {
            var result = new List<SendInvoiceCommandResponse>();

            if (!command.InvoicesToSend.Any())
            {
                var invoicesToSend = await _invoiceRepository.FindAllAsync();

                foreach (var invoice in invoicesToSend)
                {
                    var invoiceToAdd = _mapper.Map<InvoicesToSend>(invoice);
                    command.InvoicesToSend.Add(invoiceToAdd);
                }
            }           

            var response = await _httpRequestService.PostAsyncGetList<SendInvoiceCommandResponse>("SendInvoicesToProcess", command.InvoicesToSend, cancellationToken);
            result.AddRange(response);

            return result;
        }
    }
}
