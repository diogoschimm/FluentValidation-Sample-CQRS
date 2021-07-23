using FluentValidation;
using MediatR;
using System;

namespace FluentValidationSampleCore.Commands
{
    public class CriarPessoaCommand : IRequest<Pessoa>
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
    }

    public class CriarPessoaCommandValidator : AbstractValidator<CriarPessoaCommand>
    {
        public CriarPessoaCommandValidator()
        { 
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Nome é obrigatório");

            RuleFor(p => p.Nome)
                .MaximumLength(60)
                .WithMessage("Campo Nome deve possuir no máximo 60 caracteres");

            RuleFor(p => p.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo CPF é obrigatório"); 
        }
    }
}
