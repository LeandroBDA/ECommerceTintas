using ECommerceTintas.Dto.Cliente;
using ECommerceTintas.Dto.Usuario;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Usuario;

namespace ECommerceTintas.Services.Cliente;

public interface IUsuarioInterface
{
    Task<ResponseModel<List<UsuarioDto>>> ObterListaDeUsuarios();
    Task<ResponseModel<UsuarioModel>> BuscarUsuariosPorId(Guid idCliente);
    Task<ResponseModel<UsuarioModel>> CadastrarUsuario(CadastrarUsuarioDto novoUsuario);
    Task<ResponseModel<UsuarioModel>> ExcluirUsuario(Guid idCliente);
    Task<ResponseModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuario, Guid idCliente);
}