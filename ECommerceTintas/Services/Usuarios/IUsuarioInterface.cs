using ECommerceTintas.Dto.Usuario;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Usuario;

namespace ECommerceTintas.Services.Usuarios;

public interface IUsuarioInterface
{
    Task<ResponseModel<List<UsuarioDto>>> ObterListaDeUsuarios();
    Task<ResponseModel<UsuarioModel>> BuscarUsuariosPorId(int idUsuario);
    Task<ResponseModel<UsuarioModel>> CadastrarUsuario(CadastrarUsuarioDto novoUsuario);
    Task<ResponseModel<UsuarioModel>> ExcluirUsuario(int idUsuario);
    Task<ResponseModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuario, int idUsuario);
}