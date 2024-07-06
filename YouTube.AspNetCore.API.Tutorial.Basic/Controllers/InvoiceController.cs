using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : CustomBaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // baseaddress/api/Invoice/GetallInvoices
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var result = _invoiceService.GetAllInvoiceList();
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/GetInvoiceById/5
        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var result = _invoiceService.GetInvoiceById(id);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/CreateInvoice
        [HttpPost]
        public IActionResult CreateInvoice(InvoiceCreateDto request)
        {
            var result = _invoiceService.CreateInvoice(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/UpdateInvoice
        [HttpPut]
        public IActionResult UpdateInvoice(InvoiceUpdateForRemoveItemsDto request)
        {
            var result = _invoiceService.UpdateInvoice(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/DeleteInvoice
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var result = _invoiceService.DeleteInvoice(id);
            return CreateAction(result);
        }






        // baseaddress/api/Invoice/RemoveInvoiceItems
        [HttpPut()]
        public IActionResult RemoveInvoiceItems(RemoveInvoiceItemsDto request)
        {
            var result = _invoiceService.RemoveInvoiceItems(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/AddInvoiceItems
        [HttpPut()]
        public IActionResult AddInvoiceItems(AddInvoiceItemsDto request)
        {
            var result = _invoiceService.AddInvoiceItems(request);
            return CreateAction(result);
        }
    }
}
