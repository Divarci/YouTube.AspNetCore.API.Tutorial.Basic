using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices
{
    public interface IInvoiceService
    {
        #region BaseMethods
        CustomResponseDto<List<InvoiceDto>> GetAllInvoiceList();
        CustomResponseDto<InvoiceDto> GetInvoiceById(int id);
        CustomResponseDto<InvoiceCreateDto> CreateInvoice(InvoiceCreateDto request);
        CustomResponseDto<NoContentDto> UpdateInvoice(InvoiceUpdateForRemoveItemsDto request);
        CustomResponseDto<NoContentDto> DeleteInvoice(int id);
        #endregion

        #region InvoiceItemMethods
        CustomResponseDto<NoContentDto> RemoveInvoiceItems(RemoveInvoiceItemsDto request);
        CustomResponseDto<List<InvoiceItemCreateDto>> AddInvoiceItems(AddInvoiceItemsDto request);
        #endregion
    }
}
