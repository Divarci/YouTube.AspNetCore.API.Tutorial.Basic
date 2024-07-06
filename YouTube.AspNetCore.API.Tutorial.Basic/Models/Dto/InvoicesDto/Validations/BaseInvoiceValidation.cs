using System.ComponentModel.DataAnnotations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Validations
{
    public class BaseInvoiceValidation
    {
        [Required(ErrorMessage = "Invoice Date is reqiured")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Po NUmber is reqiured")]
        public string PONumber { get; set; }

        [Required(ErrorMessage = "Client Id is reqiured")]
        public int ClientId { get; set; }
    }
}
