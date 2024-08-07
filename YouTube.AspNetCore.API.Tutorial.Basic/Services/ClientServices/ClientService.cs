﻿using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Exceptions;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.MapperApp;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IGenericRepository<Client> clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public CustomResponseDto<ClientCreateDto> CreateClient(ClientCreateDto request)
        {
            var client = _mapper.Map<ClientCreateDto, Client>(request, 3);
            _clientRepository.CreateItem(client);
            return CustomResponseDto<ClientCreateDto>.Success(request, 201);
        }

        public CustomResponseDto<NoContentDto> DeleteClient(int id)
        {
            var client = _clientRepository.GetItemById(id);
            if (client is null)
            {
                throw new ClientSideException("Client not exist");
            }
            _clientRepository.DeleteItem(client);
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public CustomResponseDto<List<ClientDto>> GetAllClientList()
        {
            var clients = _clientRepository.GetAll().AsNoTracking().Include(x=>x.Invoices).ToList();
            var mappedList = _mapper.Map<List<Client>, List<ClientDto>>(clients, 3);
            return CustomResponseDto<List<ClientDto>>.Success(mappedList, 200);
        }

        public CustomResponseDto<ClientDto> GetClientById(int id)
        {
            var client = _clientRepository.GetAll().Include(x => x.Invoices).FirstOrDefault(x=>x.Id==id);
            if (client is null)
            {
                throw new ClientSideException("Client not exist");
            }
            var mappedItem = _mapper.Map<Client, ClientDto>(client, 3);
            return CustomResponseDto<ClientDto>.Success(mappedItem, 200);

        }

        public CustomResponseDto<NoContentDto> UpdateClient(ClientUpdateDto request)
        {
            var client = _clientRepository.GetAll().FirstOrDefault(x => x.Id == request.Id);
            if (client is null)
            {
                throw new ClientSideException("Client not exist");
            }
            var mappedItem = _mapper.Map(request, client, 3);
            _clientRepository.UpdateItem(mappedItem);
            return CustomResponseDto<NoContentDto>.Success(204);
        }
    }
}
