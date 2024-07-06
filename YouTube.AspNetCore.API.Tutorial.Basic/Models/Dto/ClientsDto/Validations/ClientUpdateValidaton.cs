using System.ComponentModel.DataAnnotations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Validations
{
    public class ClientUpdateValidaton : BaseClientValidation
    {
        [Required(ErrorMessage = "Client Id is required")]
        public int Id { get; set; }
    }
}
