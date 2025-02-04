using ECommerceTintas.Models;

namespace ECommerceTintas.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<List<ClienteModel>>> ListarClentes();
    Task<ResponseModel<ClienteModel>> BuscarClientePorId(Guid idCliente);
    
}