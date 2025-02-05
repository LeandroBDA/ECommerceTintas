using ECommerceTintas.Models;

namespace ECommerceTintas.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<List<ClienteModel>>> ListarClentes();
    Task<ResponseModel<ClienteModel>> BuscarClientePorId(Guid idCliente);
    Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteModel novoCliente);
    Task<ResponseModel<ClienteModel>> ExcluirCliente(Guid idCliente);
    Task<ResponseModel<ClienteModel>> AtualizarCliente(ClienteModel atualizarCliente, Guid idcliente);
    
}