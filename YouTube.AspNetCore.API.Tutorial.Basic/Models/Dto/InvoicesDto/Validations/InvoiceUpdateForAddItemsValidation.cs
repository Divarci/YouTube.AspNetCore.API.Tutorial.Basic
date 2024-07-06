using System.ComponentModel.DataAnnotations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Validations
{
    public class InvoiceUpdateForUpdateItemsValidation : BaseInvoiceValidation
    {

        [Required(ErrorMessage = "Invoice Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please assign at least one item")]
        public List<InvoiceItemCreateDto> InvoiceItems { get; set; }
    }
}
