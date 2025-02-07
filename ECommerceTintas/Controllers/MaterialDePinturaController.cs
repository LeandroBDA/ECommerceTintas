using ECommerceTintas.Dto.MaterialDePintura;
using ECommerceTintas.Models;
using ECommerceTintas.Models.MaterialDePintura;
using ECommerceTintas.Services.MaterialDePintura;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialDePinturaController : ControllerBase
    {
        private readonly IMaterialDePinturaInterface _materialDePinturaInterface;

        public MaterialDePinturaController(IMaterialDePinturaInterface materialDePinturaInterface)
        {
            _materialDePinturaInterface = materialDePinturaInterface;
        }

        [HttpGet("ListarMateriais")]
        public async Task<ActionResult<ResponseModel<List<MaterialDePinturaModel>>>> ListarMateriais()
        {
            var materiais = await _materialDePinturaInterface.ObterListaDeMateriais();
            return Ok(materiais);
        }

        [HttpPost("CadastrarMaterial")]
        public async Task<ActionResult<ResponseModel<MaterialDePinturaModel>>> CadastrarMaterial([FromBody] CadastrarMaterialDePinturaDto materialDto)
        {
            var resposta = await _materialDePinturaInterface.CadastrarMaterial(materialDto);
            return Ok(resposta);
        }
        
        [HttpGet("BuscarMaterialPorId/{idMaterial}")]
        public async Task<ActionResult<ResponseModel<MaterialDePinturaDto>>> BuscarMaterialPorId(int idMaterial)
        {
            var resposta = await _materialDePinturaInterface.BuscarMaterialPorId(idMaterial);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpPut("AtualizarMaterial/{idMaterial}")]
        public async Task<ActionResult<ResponseModel<MaterialDePinturaModel>>> AtualizarMaterial([FromForm] AtualizarMaterialDePinturaDto atualizarMaterial, int idMaterial)
        {
            var resposta = await _materialDePinturaInterface.AtualizarMaterial(atualizarMaterial, idMaterial);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirMaterial/{idMaterial}")]
        public async Task<ActionResult<ResponseModel<MaterialDePinturaModel>>> ExcluirMaterial(int idMaterial)
        {
            var resposta = await _materialDePinturaInterface.ExcluirMaterial(idMaterial);
            return Ok(resposta);
        }
    }
}
