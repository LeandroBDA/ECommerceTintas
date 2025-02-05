using ECommerceTintas.Data;
using ECommerceTintas.Dto.Usuario;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Usuario;
using ECommerceTintas.Models.Validators;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Cliente
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UsuarioDto>>> ObterListaDeUsuarios()
        {
            var resposta = new ResponseModel<List<UsuarioDto>>();
            try
            {
                var usuario = await _context.Usuarios.ToListAsync();
                var usuarioDto = usuario.Select(usuario => new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Cpf = usuario.Cpf,
                    Senha = usuario.Senha,
                    Email = usuario.Email,
                    DataDeNascimento = usuario.DataDeNascimento,
                    Complemento = usuario.Complemento,
                    Numero = usuario.Numero,
                    Cep = usuario.Cep,
                    Cidade = usuario.Cidade,
                    Estado = usuario.Estado,
                    Telefone = usuario.Telefone,
                    Endereco = usuario.Endereco
                }).ToList();

                resposta.Dados = usuarioDto;
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

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuariosPorId(Guid idUsuario)
        {
            var resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    resposta.Mensagem = "Cliente não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                resposta.Dados = usuario;
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

        public async Task<ResponseModel<UsuarioModel>> CadastrarUsuario(CadastrarUsuarioDto usuarioDto)
        {
            var resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var novoCliente = new UsuarioModel
                {
                    Nome = usuarioDto.Nome,
                    Cpf = usuarioDto.Cpf,
                    Senha = usuarioDto.Senha,
                    Email = usuarioDto.Email,
                    DataDeNascimento = usuarioDto.DataDeNascimento,
                    Complemento = usuarioDto.Complemento,
                    Numero = usuarioDto.Numero,
                    Cep = usuarioDto.Cep,
                    Cidade = usuarioDto.Cidade,
                    Estado = usuarioDto.Estado,
                    Telefone = usuarioDto.Telefone,
                    Endereco = usuarioDto.Endereco
                };

                var validator = new UsuarioValidation();
                var validationResult = validator.Validate(novoCliente);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                await _context.Usuarios.AddAsync(novoCliente);
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

        public async Task<ResponseModel<UsuarioModel>> ExcluirUsuario(Guid idUsuario)
        {
            var resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    resposta.Mensagem = "Cliente não encontrado para exclusão";
                    resposta.status = false;
                    return resposta;
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = usuario;
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

        public async Task<ResponseModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuario, Guid idUsuario)
        {
            var resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var usuarioExistente = await _context.Usuarios.FindAsync(idUsuario);
                if (usuarioExistente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado para atualização";
                    resposta.status = false;
                    return resposta;
                }

                var nomeJaCadastrado = await _context.Usuarios
                    .AnyAsync(c => c.Nome == atualizarUsuario.Nome && !Equals(c.Id, idUsuario));

                if (nomeJaCadastrado)
                {
                    resposta.Mensagem = "O nome informado já está cadastrado para outro cliente.";
                    resposta.status = false;
                    return resposta;
                }

                usuarioExistente.Nome = atualizarUsuario.Nome;
                usuarioExistente.Cpf = atualizarUsuario.Cpf;
                usuarioExistente.Senha = atualizarUsuario.Senha;
                usuarioExistente.Email = atualizarUsuario.Email;
                usuarioExistente.DataDeNascimento = atualizarUsuario.DataDeNascimento;
                usuarioExistente.Complemento = atualizarUsuario.Complemento;
                usuarioExistente.Numero = atualizarUsuario.Numero;
                usuarioExistente.Cep = atualizarUsuario.Cep;
                usuarioExistente.Cidade = atualizarUsuario.Cidade;
                usuarioExistente.Estado = atualizarUsuario.Estado;
                usuarioExistente.Telefone = atualizarUsuario.Telefone;
                usuarioExistente.Endereco = atualizarUsuario.Endereco;

                var validator = new UsuarioValidation.AtualizarClienteValidation();
                var validationResult = validator.Validate(usuarioExistente);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                _context.Usuarios.Update(usuarioExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = usuarioExistente;
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