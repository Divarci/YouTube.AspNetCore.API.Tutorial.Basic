using System.ComponentModel.DataAnnotations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Validations
{
    public class InvoiceItemIUpdateValidation : BaseInvoiceItemValidation
    {
        [Required(ErrorMessage = "Item Id is required")]
        public int Id { get; set; }
    }
}
