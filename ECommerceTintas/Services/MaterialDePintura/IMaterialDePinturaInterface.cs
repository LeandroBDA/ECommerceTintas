using ECommerceTintas.Dto.MaterialDePintura;
using ECommerceTintas.Models;
using ECommerceTintas.Models.MaterialDePintura;

namespace ECommerceTintas.Services.MaterialDePintura
{
    public interface IMaterialDePinturaInterface
    {
        Task<ResponseModel<List<MaterialDePinturaDto>>> ObterListaDeMateriais();
        Task<ResponseModel<MaterialDePinturaModel>> BuscarMaterialPorId(int idMaterial);
        Task<ResponseModel<MaterialDePinturaModel>> CadastrarMaterial(CadastrarMaterialDePinturaDto novoMaterial);
        Task<ResponseModel<MaterialDePinturaModel>> ExcluirMaterial(int idMaterial);
        Task<ResponseModel<MaterialDePinturaModel>> AtualizarMaterial(AtualizarMaterialDePinturaDto atualizarMaterial, int idMaterial);
    }
}
