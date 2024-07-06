using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto
{
    public class InvoiceItemUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Vat { get => Total * 0.2m; private set { } }
        public decimal Total { get => Price * Quantity; private set { } }
        public decimal GrandTotal { get => Total + Vat; private set { } }
      
    }
}
