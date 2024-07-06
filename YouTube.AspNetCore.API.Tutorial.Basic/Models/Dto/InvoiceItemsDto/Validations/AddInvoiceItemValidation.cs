using System.ComponentModel.DataAnnotations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Validations
{
    public class AddInvoiceItemValidation
    {
        [Required(ErrorMessage = "Invoice Id is required")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Item List is required")]
        public List<InvoiceItemCreateDto> InvoiceItemList { get; set; }
    }
}
