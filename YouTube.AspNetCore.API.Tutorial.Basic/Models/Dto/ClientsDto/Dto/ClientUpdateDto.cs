using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Validations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto
{
    [ModelMetadataType(typeof(ClientUpdateValidaton))]
    public class ClientUpdateDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
