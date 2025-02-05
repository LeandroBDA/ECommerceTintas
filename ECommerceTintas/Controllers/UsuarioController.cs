using ECommerceTintas.Dto.Usuario;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Usuario;
using ECommerceTintas.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var cliente = await _usuarioInterface.ObterListaDeUsuarios();
            return Ok(cliente);
        }

        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> CadastrarUsuario([FromBody] CadastrarUsuarioDto usuarioDto)
        {
            var resposta = await _usuarioInterface.CadastrarUsuario(usuarioDto);
            return Ok(resposta);
        }
        
        [HttpGet("BuscarClientePorId/{idCliente}")]
        public async Task<ActionResult<ResponseModel<UsuarioDto>>> BuscarUsuariosPorId(Guid idCliente)
        {
            var resposta = await _usuarioInterface.BuscarUsuariosPorId(idCliente);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }


        [HttpPut("AtualizarCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> AtualizarUsuario([FromForm] AtualizarUsuarioDto atualizarUsuario, Guid idCliente)
        {
            var resposta = await _usuarioInterface.AtualizarUsuario(atualizarUsuario, idCliente);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> ExcluirUsuario(Guid idCliente)
        {
            var resposta = await _usuarioInterface.ExcluirUsuario(idCliente);
            return Ok(resposta);
        }
    }
}