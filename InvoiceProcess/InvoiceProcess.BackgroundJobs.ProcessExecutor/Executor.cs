using InvoiceProcess.Application.Core.Common.Messages.Invoice;
using InvoiceProcess.Application.Core.Features.Invoices.Commands.Create;
using InvoiceProcess.Application.Core.Features.Invoices.Commands.Send;
using InvoiceProcess.Domain.Core.Services;
using InvoiceProcess.Infrasctructure.Core.Services.FileHandler;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceProcess.BackgroundJobs.ProcessExecutor
{
    public class Executor
    {
        private readonly IQueuesService _queuesService;
        private readonly ExcelHandler _excelHandler;

        public Executor(ExcelHandler excelHandler, IQueuesService queuesService)
        {
            _queuesService = queuesService;
            _excelHandler = excelHandler;
        }

        [FunctionName("Executor")]
        public async Task Run([TimerTrigger("0 */3 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            string excelRoute = @"C:\files\data_prueba_facturas.xlsx";
            string workSheetName = @"data_prueba_facturas";

            List<CreateInvoiceCommand> commandList = _excelHandler.GetListFromExcelFile<CreateInvoiceCommand>(excelRoute, workSheetName);

            log.LogInformation($"Invoice list from excel file: {JsonSerializer.Serialize(commandList)}");

            foreach (CreateInvoiceCommand command in commandList)
            {
                //_mediator.Send(command);

                await _queuesService.QueueAsync("create-new-invoice", new CreateInvoiceMessage
                {
                    CreateInvoiceCommand = command
                });
                log.LogInformation($"Invoice sent to create: {JsonSerializer.Serialize(command)}");
            }
            log.LogInformation($"Invoice list sent to create");

            await Task.Delay(TimeSpan.FromSeconds(10));

            log.LogInformation($"Invoice send command in process..");
            await _queuesService.QueueAsync("send-invoice", new SendInvoiceCommand());
            log.LogInformation($"Invoice send command finished!");

        }
    }
}
