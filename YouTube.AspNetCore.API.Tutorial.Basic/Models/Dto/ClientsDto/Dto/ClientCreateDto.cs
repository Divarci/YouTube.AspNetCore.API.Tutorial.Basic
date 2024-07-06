using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Validations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto
{
    [ModelMetadataType(typeof(BaseClientValidation))]
    public class ClientCreateDto
    {
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
