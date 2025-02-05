using ECommerceTintas.Data;
using ECommerceTintas.Dto.Cliente;
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

        public async Task<ResponseModel<List<ClienteDto>>> ListarClentes()
        {
            var resposta = new ResponseModel<List<ClienteDto>>();
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                
                var clientesDto = clientes.Select(cliente => new ClienteDto
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    Endereco = cliente.Endereco
                }).ToList();

                resposta.Dados = clientesDto;
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

        public async Task<ResponseModel<ClienteDto>> BuscarClientePorId(Guid idCliente)
        {
            var resposta = new ResponseModel<ClienteDto>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(idCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                var clienteDto = new ClienteDto
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    Endereco = cliente.Endereco
                };

                resposta.Dados = clienteDto;
                resposta.Mensagem = "Cliente encontrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteDto>> CadastrarCliente(CadastrarClienteDto clienteDto)
        {
            var resposta = new ResponseModel<ClienteDto>();
            try
            {
                var novoCliente = new ClienteModel
                {
                    Nome = clienteDto.Nome,
                    Cpf = clienteDto.Cpf,
                    Senha = clienteDto.Senha,
                    Email = clienteDto.Email,
                    DataDeNascimento = clienteDto.DataDeNascimento,
                    Complemento = clienteDto.Complemento,
                    Cep = clienteDto.Cep,
                    Cidade = clienteDto.Cidade,
                    Estado = clienteDto.Estado,
                    Telefone = clienteDto.Telefone,
                    Endereco = clienteDto.Endereco
                };

                await _context.Clientes.AddAsync(novoCliente);
                await _context.SaveChangesAsync();

                var clienteResponse = new ClienteDto
                {
                    Nome = clienteDto.Nome,
                    Cpf = clienteDto.Cpf,
                    Senha = clienteDto.Senha,
                    Email = clienteDto.Email,
                    DataDeNascimento = clienteDto.DataDeNascimento,
                    Complemento = clienteDto.Complemento,
                    Cep = clienteDto.Cep,
                    Cidade = clienteDto.Cidade,
                    Estado = clienteDto.Estado,
                    Telefone = clienteDto.Telefone,
                    Endereco = clienteDto.Endereco
                };

                resposta.Dados = clienteResponse;
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

        public async Task<ResponseModel<ClienteDto>> ExcluirCliente(ExcluirClienteDto idCliente)
        {
            var resposta = new ResponseModel<ClienteDto>();
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

                var clienteDto = new ClienteDto
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Senha = cliente.Senha,
                    Email = cliente.Email,
                    DataDeNascimento = cliente.DataDeNascimento,
                    Complemento = cliente.Complemento,
                    Cep = cliente.Cep,
                    Cidade = cliente.Cidade,
                    Estado = cliente.Estado,
                    Telefone = cliente.Telefone,
                    Endereco = cliente.Endereco
                };

                resposta.Dados = clienteDto;
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

        public async Task<ResponseModel<ClienteDto>> AtualizarCliente(AtualizarClienteDto atualizarCliente, Guid idCliente)
        {
            var resposta = new ResponseModel<ClienteDto>();
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
                clienteExistente.Cpf = atualizarCliente.Cpf;
                clienteExistente.Senha = atualizarCliente.Senha;
                clienteExistente.Email = atualizarCliente.Email;
                clienteExistente.DataDeNascimento = atualizarCliente.DataDeNascimento;
                clienteExistente.Complemento = atualizarCliente.Complemento;
                clienteExistente.Cep = atualizarCliente.Cep;
                clienteExistente.Cidade = atualizarCliente.Cidade;
                clienteExistente.Estado = atualizarCliente.Estado;
                clienteExistente.Telefone = atualizarCliente.Telefone;
                clienteExistente.Endereco = atualizarCliente.Endereco;


                _context.Clientes.Update(clienteExistente);
                await _context.SaveChangesAsync();

                var clienteDto = new ClienteDto
                {
                 
                    Nome = clienteExistente.Nome,
                    Cpf = clienteExistente.Cpf,
                    Senha = clienteExistente.Senha,
                    Email = clienteExistente.Email,
                    DataDeNascimento = clienteExistente.DataDeNascimento,
                    Complemento = clienteExistente.Complemento,
                    Cep = clienteExistente.Cep,
                    Cidade = clienteExistente.Cidade,
                    Estado = clienteExistente.Estado,
                    Telefone = clienteExistente.Telefone,
                    Endereco = clienteExistente.Endereco
                };

                resposta.Dados = clienteDto;
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