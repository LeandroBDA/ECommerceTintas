using ECommerceTintas.Dto.Tinta;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Tinta;

namespace ECommerceTintas.Services.Tinta
{
    public interface ITintaInterface
    {
        Task<ResponseModel<List<TintaDto>>> ObterListaDeTintas();
        Task<ResponseModel<TintaModel>> BuscarTintaPorId(int idTinta);
        Task<ResponseModel<TintaModel>> CadastrarTinta(CadastrarTintaDto novaTinta);
        Task<ResponseModel<TintaModel>> ExcluirTinta(int idTinta);
        Task<ResponseModel<TintaModel>> AtualizarTinta(AtualizarTintaDto atualizarTinta, int idTinta);
    }
}
