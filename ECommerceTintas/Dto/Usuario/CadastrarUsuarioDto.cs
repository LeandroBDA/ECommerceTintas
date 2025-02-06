namespace ECommerceTintas.Dto.Usuario;

public class CadastrarUsuarioDto
{
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public DateOnly DataDeNascimento { get; set; }
    public string Endereco { get; set; } = null!;
    public int Numero { get; set; }
    public string Complemento { get; set; } = null!;
    public int Cep { get; set; } 
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
}