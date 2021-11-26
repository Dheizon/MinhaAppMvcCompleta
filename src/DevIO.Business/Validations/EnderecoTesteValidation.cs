using DevIO.Business.Models;
using FluentValidation;

namespace DevIO.Business.Validations
{
    public class EnderecoTesteValidation : AbstractValidator<EnderecoTeste>
    {
        public EnderecoTesteValidation()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .MinimumLength(2).WithMessage("O campo {PropertyName} precisa ter entre {MinimumLength} caracteres");



            //... continuar
        }
    }
}
