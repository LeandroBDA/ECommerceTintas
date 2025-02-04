using ECommerceTintas.Models;
using ECommerceTintas.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClentes()
        {
            var cliente = await _clienteInterface.ListarClentes();
            return Ok(cliente);
        }
        
    }
}
