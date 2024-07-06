﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Validations;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto
{
    [ModelMetadataType(typeof(AddInvoiceItemValidation))]
    public class AddInvoiceItemsDto
    {
        public int InvoiceId { get; set; }
        public List<InvoiceItemCreateDto> InvoiceItemList { get; set; }
    }
}
