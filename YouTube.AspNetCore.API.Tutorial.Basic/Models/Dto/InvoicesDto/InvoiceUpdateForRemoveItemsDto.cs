using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto
{
    public class InvoiceUpdateForRemoveItemsDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PONumber { get; set; }
        public decimal Vat { get => InvoiceItems.Sum(x => x.Vat); private set { } }
        public decimal Total { get => InvoiceItems.Sum(x => x.Total); private set { } }
        public decimal GrandTotal { get => InvoiceItems.Sum(x => x.GrandTotal); private set { } }
        public int ClientId { get; set; }

        public List<InvoiceItemUpdateDto> InvoiceItems { get; set; }


    }
}
