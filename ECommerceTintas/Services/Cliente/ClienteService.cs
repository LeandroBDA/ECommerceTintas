using ECommerceTintas.Data;
using ECommerceTintas.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Cliente
{
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

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorId(Guid idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(idCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado";
                    resposta.status = false;
                }
                else
                {
                    resposta.Dados = cliente;
                    resposta.Mensagem = "Cliente encontrado com sucesso";
                }
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteModel novoCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                await _context.Clientes.AddAsync(novoCliente);
                await _context.SaveChangesAsync();

                resposta.Dados = novoCliente;
                resposta.Mensagem = "Cliente cadastrado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> ExcluirCliente(Guid idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(idCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado para exclusão";
                    resposta.status = false;
                    return resposta;
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente excluído com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> AtualizarCliente(ClienteModel atualizarCliente, Guid idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var clienteExistente = await _context.Clientes.FindAsync(idCliente);
                if (clienteExistente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado para atualização";
                    resposta.status = false;
                    return resposta;
                }

                clienteExistente.Nome = atualizarCliente.Nome;
                clienteExistente.Email = atualizarCliente.Email;
                clienteExistente.Telefone = atualizarCliente.Telefone;
                // Adicione outros campos conforme necessário

                _context.Clientes.Update(clienteExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = clienteExistente;
                resposta.Mensagem = "Cliente atualizado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }
    }
}
