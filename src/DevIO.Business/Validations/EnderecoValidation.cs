using AppMvcBasica.Models;
using FluentValidation;

namespace DevIO.Business.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecedido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");


            //... continuar
        }
    }
}
