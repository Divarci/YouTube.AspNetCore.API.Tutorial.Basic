﻿namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto
{
    public class InvoiceDtoForClient
    {
        public DateTime InvoiceDate { get; set; }
        public string PONumber { get; set; }       
        public decimal GrandTotal { get; set; }
    }
}
