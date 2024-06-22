﻿using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
