using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.MapperApp;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        #region BaseMethods
        public CustomResponseDto<InvoiceCreateDto> CreateInvoice(InvoiceCreateDto request)
        {
            var invoice = _mapper.Map<InvoiceCreateDto, Invoice>(request, 3);
            _invoiceRepository.CreateItem(invoice);
            return CustomResponseDto<InvoiceCreateDto>.Success(request, 201);
        }

        public CustomResponseDto<NoContentDto> DeleteInvoice(int id)
        {
            var invoice = _invoiceRepository.GetItemById(id);
            if (invoice is null)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Invoice not exist.");
            }
            _invoiceRepository.DeleteItem(invoice);
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public CustomResponseDto<List<InvoiceDto>> GetAllInvoiceList()
        {
            var invoices = _invoiceRepository.GetAll().Include(x => x.InvoiceItems).Include(x => x.Client).ToList();
            var mappedList = _mapper.Map<List<Invoice>, List<InvoiceDto>>(invoices, 3);
            return CustomResponseDto<List<InvoiceDto>>.Success(mappedList, 200);
        }

        public CustomResponseDto<InvoiceDto> GetInvoiceById(int id)
        {
            var invoice = _invoiceRepository.GetAll().Include(x => x.InvoiceItems).Include(x => x.Client).FirstOrDefault(x=>x.Id==id);
            if (invoice is null)
            {
                return CustomResponseDto<InvoiceDto>.Fail(400, "Invoice not exist.");
            }
            var mappedItem = _mapper.Map<Invoice, InvoiceDto>(invoice, 3);
            return CustomResponseDto<InvoiceDto>.Success(mappedItem, 200);

        }

        public CustomResponseDto<NoContentDto> UpdateInvoice(InvoiceUpdateForRemoveItemsDto request)
        {
            var invoice = _invoiceRepository.GetAll().FirstOrDefault(x => x.Id == request.Id);
            if (invoice is null)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Invoice not exist.");
            }
            var mappedItem = _mapper.Map(request,invoice ,3);
            _invoiceRepository.UpdateItem(mappedItem);
            return CustomResponseDto<NoContentDto>.Success(204);
        }
        #endregion

        #region InvoiceItemMethods
        public CustomResponseDto<NoContentDto> RemoveInvoiceItems(RemoveInvoiceItemsDto request)
        {
            var invoice = _invoiceRepository //tracked
                .GetAll()
                .Include(x=>x.InvoiceItems)
                .FirstOrDefault(x => x.Id == request.InvoiceId);

            if (invoice is null)            
                return CustomResponseDto<NoContentDto>.Fail(400, "Invoice not exist."); 
            
            var invoiceDto = _mapper.Map<Invoice,InvoiceUpdateForRemoveItemsDto>(invoice, 3);

            List<string> errorMessages = new();
            foreach (var removeItemId in request.RemoveInvoiceItemIdList) 
            {
                var removeItem = invoiceDto.InvoiceItems.FirstOrDefault(x => x.Id == removeItemId);
                if (removeItem is null)
                {
                    errorMessages.Add($"Item no:{removeItemId} not exist");
                    continue;
                }
                invoiceDto.InvoiceItems.Remove(removeItem);
            }

            if(errorMessages.Any())
                return CustomResponseDto<NoContentDto>.Fail(400, errorMessages);

            var updtedInvoice = _mapper.Map(invoiceDto,invoice, 3);

            if (!updtedInvoice.InvoiceItems.Any())
                _invoiceRepository.DeleteItem(updtedInvoice);
            else 
                _invoiceRepository.UpdateItem(updtedInvoice);

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public CustomResponseDto<List<InvoiceItemCreateDto>> AddInvoiceItems(AddInvoiceItemsDto request)
        {
            var invoice = _invoiceRepository //tracked
                .GetAll()
                .Include(x => x.InvoiceItems)
                .FirstOrDefault(x => x.Id == request.InvoiceId);

            if (invoice is null)
                return CustomResponseDto<List<InvoiceItemCreateDto>>.Fail(400, "Invoice not exist.");

            var invoiceDto = _mapper.Map<Invoice, InvoiceUpdateForAddItemsDto>(invoice, 3);
            invoiceDto.InvoiceItems!.AddRange(request.InvoiceItemList);            

            var updtedInvoice = _mapper.Map(invoiceDto, invoice, 3);
            _invoiceRepository.UpdateItem(updtedInvoice);
            return CustomResponseDto<List<InvoiceItemCreateDto>>.Success(request.InvoiceItemList,201);
        }

        #endregion

    }
}
