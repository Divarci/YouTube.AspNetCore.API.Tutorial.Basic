namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto
{
    public class AddInvoiceItemsDto
    {
        public int InvoiceId { get; set; }
        public List<InvoiceItemCreateDto> InvoiceItemList { get; set; }
    }
}
