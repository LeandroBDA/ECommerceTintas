using ECommerceTintas.Dto.Cliente;
using ECommerceTintas.Models;

namespace ECommerceTintas.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<List<ClienteDto>>> ListarClentes();
    Task<ResponseModel<ClienteDto>> BuscarClientePorId(Guid idCliente);
    Task<ResponseModel<ClienteDto>> CadastrarCliente(CadastrarClienteDto novoCliente);
    Task<ResponseModel<ClienteDto>> ExcluirCliente(ExcluirClienteDto idCliente);
    Task<ResponseModel<ClienteDto>> AtualizarCliente(AtualizarClienteDto atualizarCliente, Guid idCliente);
}