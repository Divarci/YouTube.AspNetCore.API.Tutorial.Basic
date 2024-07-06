using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PONumber { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }

        public int ClientId { get; set; }
        public ClientDtoForInvoice Client { get; set; }

        public List<InvoiceItemDto> InvoiceItems { get; set; }
    }
}
