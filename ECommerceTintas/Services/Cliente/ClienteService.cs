using ECommerceTintas.Data;
using ECommerceTintas.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Cliente;

public class ClienteService : IClienteInterface
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<List<ClienteModel>>> ListarClentes()
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var clientes = await _context.Clientes.ToListAsync();

            resposta.Dados = clientes;
            resposta.Mensagem = "Todos os clientes foram listados";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.status = false;
            return resposta;
        }
    }

    public Task<ResponseModel<ClienteModel>> BuscarClientePorId(Guid idCliente)
    {
        throw new NotImplementedException();
    }
}