using ClienteProject.Domain.ValueObjects;
using ClienteProject.Domain.ValueObjects;
using FluentValidation;

namespace ClienteProject.Application.UseCases.CadastrarCliente;

public class CadastrarClienteInputValidator : AbstractValidator<CadastrarClienteInput>
{
    public CadastrarClienteInputValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(200).WithMessage("Nome não deve exceder 200 caracteres.");

        RuleFor(x => x.Cpf)
       .Must(Cpf.IsValid).WithMessage("CPF inválido.");

        RuleFor(x => x.Email)
            .Must(Email.IsValid).WithMessage("Email inválido.");

        RuleFor(x => x.Telefone)
            .Must(Telefone.IsValid).WithMessage("Telefone inválido.");

        RuleFor(x => x.Cep)
            .Must(Cep.IsValid).WithMessage("CEP inválido.");

        RuleFor(x => x.Logradouro)
            .NotEmpty().WithMessage("Logradouro é obrigatório.")
            .MaximumLength(300).WithMessage("Logradouro não deve exceder 300 caracteres.");

        RuleFor(x => x.Numero)
            .NotEmpty().WithMessage("Número é obrigatório.")
            .MaximumLength(10).WithMessage("Número não deve exceder 10 caracteres.");

        RuleFor(x => x.Complemento)
            .MaximumLength(200).WithMessage("Complemento não deve exceder 200 caracteres.");

        RuleFor(x => x.Bairro)
            .NotEmpty().WithMessage("Bairro é obrigatório.")
            .MaximumLength(150).WithMessage("Bairro não deve exceder 150 caracteres.");

        RuleFor(x => x.Cidade)
            .NotEmpty().WithMessage("Cidade é obrigatório.")
            .MaximumLength(150).WithMessage("Cidade não deve exceder 150 caracteres.");

        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("Estado é obrigatório.")
            .Length(2).WithMessage("Estado deve ter 2 caracteres."); // Ex.: SP, RJ
    }
}
