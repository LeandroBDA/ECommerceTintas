using ECommerceTintas.Models.Usuario;
using ECommerceTintas.Models.Usuario;
using FluentValidation;

namespace ECommerceTintas.Models.Validators;

public class UsuarioValidation : AbstractValidator<UsuarioModel>
{
    public UsuarioValidation()
    {
        
        RuleFor(cliente => cliente.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.")
            .Matches(@"^[a-zA-ZÀ-ú\s]+$").WithMessage("O nome deve conter apenas letras e espaços.");
        
        RuleFor(cliente => cliente.Cpf)
            .NotEmpty().WithMessage("O CPF é obrigatório.")
            .Length(11).WithMessage("CPF inválido.");
        
        RuleFor(cliente => cliente.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.");
        
        RuleFor(cliente => cliente.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
            .MaximumLength(20).WithMessage("A senha deve ter no máximo 20 caracteres.")
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")
            .WithMessage("A senha deve conter pelo menos uma letra e um número.");
        
        RuleFor(cliente => cliente.Telefone)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .Must(ValidarTelefone).WithMessage("Telefone inválido.");
        
        RuleFor(cliente => cliente.DataDeNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("A data de nascimento deve ser no passado.");
        
        RuleFor(cliente => cliente.Endereco)
            .NotEmpty().WithMessage("O endereço é obrigatório.")
            .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");
        
        RuleFor(cliente => cliente.Complemento)
            .MaximumLength(100).WithMessage("O complemento deve ter no máximo 100 caracteres.");
        
        RuleFor(cliente => cliente.Cep)
            .NotEmpty().WithMessage("O CEP é obrigatório.")
            .Must(ValidarCep).WithMessage("CEP inválido.");

        RuleFor(cliente => cliente.Numero)
            .NotEmpty().WithMessage("O número é obrigatório");
        
        RuleFor(cliente => cliente.Cidade)
            .NotEmpty().WithMessage("A cidade é obrigatória.")
            .MaximumLength(100).WithMessage("A cidade deve ter no máximo 100 caracteres.");
        
        RuleFor(cliente => cliente.Estado)
            .NotEmpty().WithMessage("O estado é obrigatório.")
            .Length(2).WithMessage("O estado deve ter exatamente 2 caracteres.")
            .Matches(@"^[A-Z]{2}$").WithMessage("O estado deve ser a sigla em maiúsculas (ex: SP, RJ).");
    }
    
    public class AtualizarClienteValidation : AbstractValidator<UsuarioModel>
    {
        public AtualizarClienteValidation()
        {
           
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .Length(3, 100).WithMessage("O campo Nome deve conter 3 a 100 caracteres")
                .Matches("^[a-zA-ZÀ-ÿ ]+$").WithMessage("O campo Nome deve conter somente letras.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo E-mail é obrigatório.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("O campo E-mail deve ser um endereço de e-mail válido.");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.");

            RuleFor(cliente => cliente.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");

            RuleFor(cliente => cliente.Complemento)
                .MaximumLength(100).WithMessage("O complemento deve ter no máximo 100 caracteres.");
            
            RuleFor(cliente => cliente.Numero)
                .NotEmpty().WithMessage("O número é obrigatório");

            RuleFor(cliente => cliente.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.");

            RuleFor(cliente => cliente.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade deve ter no máximo 100 caracteres.");

            RuleFor(cliente => cliente.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter exatamente 2 caracteres.")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado deve ser a sigla em maiúsculas (ex: SP, RJ).");
            
        }
    }
    private bool ValidarTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone)) 
            return false;
      
        telefone = new string(telefone.Where(char.IsDigit).ToArray());
        
        return telefone.Length == 11 && telefone[2] == '9';
    }

    
    private bool ValidarCep(int cep)
    {
        var cepString = cep.ToString("D8");
        return cepString.Length == 8;
    }
}