using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices
{
    public interface IClientService
    {
        CustomResponseDto<List<ClientDto>> GetAllClientList();
        CustomResponseDto<ClientDto> GetClientById(int id);
        CustomResponseDto<ClientCreateDto> CreateClient(ClientCreateDto request);
        CustomResponseDto<NoContentDto> UpdateClient(ClientUpdateDto request);
        CustomResponseDto<NoContentDto> DeleteClient(int id);
    }
}
