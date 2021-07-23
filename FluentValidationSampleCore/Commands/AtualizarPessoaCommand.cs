using FluentValidation;
using MediatR;
using System;

namespace FluentValidationSampleCore.Commands
{
    public class AtualizarPessoaCommand : IRequest<Pessoa>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
    }

    public class AtualizarPessoaCommandValidator : AbstractValidator<AtualizarPessoaCommand>
    {
        public AtualizarPessoaCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Campo Id não pode ser null")
                .NotEmpty()
                .WithMessage("Campo Id não pode ser branco");

            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Nome é obrigatório");

            RuleFor(p => p.Nome)
                .MaximumLength(10)
                .WithMessage("Campo Nome deve possuir no máximo 10 caracteres");

            RuleFor(p => p.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo CPF é obrigatório");
        }
    }
}
