using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace FluentValidationSampleCore.Commands
{
    public class ExcluirPessoaCommand : IRequest<Pessoa>
    {
        public ExcluirPessoaCommand(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        public ValidationResult Validate()
        {
            var result = new ExcluirPessoaCommandValidator().Validate(this);
            return result;
        }
    }

    public class ExcluirPessoaCommandValidator : AbstractValidator<ExcluirPessoaCommand>
    {
        public ExcluirPessoaCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Id é obrigatório");
        }
    }
}
