﻿namespace ECommerceTintas.Dto.Usuario;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; } 
    public string Cpf { get; set; } 
    public string Email { get; set; } 
    public string Senha { get; set; } 
    public string Telefone { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public string Endereco { get; set; } 
    public int Numero { get; set; }
    public string Complemento { get; set; } 
    public int Cep { get; set; } 
    public string Cidade { get; set; }
    public string Estado { get; set; } 
}