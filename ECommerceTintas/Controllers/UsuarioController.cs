using ECommerceTintas.Dto.Usuario;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Usuario;
using ECommerceTintas.Services.Usuarios;
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
        
        [HttpGet("BuscarClientePorId/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioDto>>> BuscarUsuariosPorId(int idUsuario)
        {
            var resposta = await _usuarioInterface.BuscarUsuariosPorId(idUsuario);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }


        [HttpPut("AtualizarCliente/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> AtualizarUsuario([FromBody] AtualizarUsuarioDto atualizarUsuario,
            int idUsuario)
        {
            var resposta = await _usuarioInterface.AtualizarUsuario(atualizarUsuario, idUsuario);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirCliente/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> ExcluirUsuario(int idUsuario)
        {
            var resposta = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(resposta);
        }
    }
}