using ECommerceTintas.Dto.Tinta;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Tinta;
using ECommerceTintas.Services.Tinta;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TintaController : ControllerBase
    {
        private readonly ITintaInterface _tintaInterface;

        public TintaController(ITintaInterface tintaInterface)
        {
            _tintaInterface = tintaInterface;
        }

        [HttpGet("ListarTintas")]
        public async Task<ActionResult<ResponseModel<List<TintaModel>>>> ListarTintas()
        {
            var tintas = await _tintaInterface.ObterListaDeTintas();
            return Ok(tintas);
        }

        [HttpPost("CadastrarTinta")]
        public async Task<ActionResult<ResponseModel<TintaModel>>> CadastrarTinta([FromBody] CadastrarTintaDto tintaDto)
        {
            var resposta = await _tintaInterface.CadastrarTinta(tintaDto);
            return Ok(resposta);
        }
        
        [HttpGet("BuscarTintaPorId/{idTinta}")]
        public async Task<ActionResult<ResponseModel<TintaDto>>> BuscarTintaPorId(int idTinta)
        {
            var resposta = await _tintaInterface.BuscarTintaPorId(idTinta);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpPut("AtualizarTinta/{idTinta}")]
        public async Task<ActionResult<ResponseModel<TintaModel>>> AtualizarTinta([FromBody] AtualizarTintaDto atualizarTinta, int idTinta)
        {
            var resposta = await _tintaInterface.AtualizarTinta(atualizarTinta, idTinta);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirTinta/{idTinta}")]
        public async Task<ActionResult<ResponseModel<TintaModel>>> ExcluirTinta(int idTinta)
        {
            var resposta = await _tintaInterface.ExcluirTinta(idTinta);
            return Ok(resposta);
        }
    }
}
