using System.ComponentModel.DataAnnotations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Validations
{
    public class RemoveInvoiceItemValidation
    {
        [Required(ErrorMessage = "Invoice Id is required")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Item List is required")]
        public List<int> RemoveInvoiceItemIdList { get; set; }
    }
}
