namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto
{
    public class RemoveInvoiceItemsDto
    {
        public int InvoiceId { get; set; }
        public List<int> RemoveInvoiceItemIdList { get; set; }
    }
}
