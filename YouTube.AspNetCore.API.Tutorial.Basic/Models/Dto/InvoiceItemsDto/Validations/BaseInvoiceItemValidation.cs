using System.ComponentModel.DataAnnotations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Validations
{
    public class BaseInvoiceItemValidation
    {
        [MaxLength(50, ErrorMessage = "Item Name must be 50 character or less")]
        [Required(ErrorMessage = "Item name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Item quantity is required")]
        public int Quantity { get; set; }
    }
}
