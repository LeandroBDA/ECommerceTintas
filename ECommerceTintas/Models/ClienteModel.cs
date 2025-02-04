namespace ECommerceTintas.Models;

public class ClienteModel
{
    public Guid Id { get; init; } 
    public string Nome { get; private set; } 
    public int Cpf { get; set; } 
    public string Email { get; set; } 
    public string Senha { get; set; } 
    public int? Telefone { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public string Endereco { get; set; } 
    public string Complemento { get; set; } 
    public int Cep { get; set; } 
    public string Cidade { get; set; }
    public string Estado { get; set; } 
}