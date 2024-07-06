using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public List<InvoiceDtoForClient> Invoices { get; set; }
    }
}
