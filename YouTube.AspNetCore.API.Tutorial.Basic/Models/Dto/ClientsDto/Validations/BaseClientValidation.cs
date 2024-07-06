using System.ComponentModel.DataAnnotations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Validations
{
    public class BaseClientValidation
    {
        [MaxLength(50, ErrorMessage = "Company Name must be 50 character or less")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [MaxLength(50, ErrorMessage = "Owner name must be 50 character or less")]
        [Required(ErrorMessage = "Company Owner is required")]
        public string Owner { get; set; }

        [MaxLength(500,ErrorMessage = "Address must be 500 character or less")]
        [Required(ErrorMessage = "Company Address is required")]
        public string Address { get; set; }

        [MaxLength(14, ErrorMessage = "Phone number must be 14 character or less")]
        [Required(ErrorMessage = "Company Phone is required")]
        public string Phone { get; set; }
    }
}
