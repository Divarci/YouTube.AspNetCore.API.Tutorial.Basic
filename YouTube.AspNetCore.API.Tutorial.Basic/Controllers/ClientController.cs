using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CustomBaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // baseaddress/api/client
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClientList();
            return CreateAction(result);
        }

        // baseaddress/api/client/{id}
        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            var result = _clientService.GetClientById(id);
            return CreateAction(result);
        }

        // baseaddress/api/client
        [HttpPost]
        public IActionResult CreateClient(ClientCreateDto request)
        {
            var result = _clientService.CreateClient(request);
            return CreateAction(result);
        }

        // baseaddress/api/client
        [HttpPut]
        public IActionResult UpdateClient(ClientUpdateDto request)
        {
            var result = _clientService.UpdateClient(request);
            return CreateAction(result);
        }

        // baseaddress/api/client/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var result = _clientService.DeleteClient(id);
            return CreateAction(result);
        }
    }
}
