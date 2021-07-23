# FluentValidation-Sample-CQRS
Exemplo de utilização do FluentValidation + MediatR


## Startup

```c#
    services.AddMediatR(typeof(Startup));

    services.AddMvc().AddFluentValidation(fv => {
        fv.ImplicitlyValidateRootCollectionElements = true; // Para collections 
        fv.RegisterValidatorsFromAssemblyContaining<AtualizarPessoaCommandValidator>();
    });

    services.AddScoped<IPessoaRepository, PessoaRepository>();
    services.AddScoped<IPessoaQuery, PessoaQuery>();

    services.AddScoped<IRequestHandler<CriarPessoaCommand, Pessoa>, PessoaCommandHandler>();
    services.AddScoped<IRequestHandler<AtualizarPessoaCommand, Pessoa>, PessoaCommandHandler>();
    services.AddScoped<IRequestHandler<ExcluirPessoaCommand, Pessoa>, PessoaCommandHandler>();

    services.AddScoped<IRequestHandler<ObterClientePorIdQuery, Pessoa>, PessoaQueryHandler>();
    services.AddScoped<IRequestHandler<ObterTodosClientesQuery, IEnumerable<Pessoa>>, PessoaQueryHandler>();
```

## Controller

```c#
  [HttpGet("{id}")]
  public async Task<IActionResult> Get(string id)
  {
      var result = await this._mediator.Send(new ObterClientePorIdQuery(id));
      return Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CriarPessoaCommand command)
  {
      var result = await this._mediator.Send(command);
      return Ok(result);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(string id, [FromBody] AtualizarPessoaCommand command)
  {
      command.Id = id;
      var result = await this._mediator.Send(command);
      return Ok(result);
  }
```

Exemplo de Validação manual

```c#
  [HttpDelete("{id?}")]
  public async Task<IActionResult> Delete(string id)
  {
      var command = new ExcluirPessoaCommand(id);
      var validations = command.Validate();

      if (!validations.IsValid)
      {
          this.AddErrors(validations); 
          return BadRequest(new { errors = ModelState } );
      }

      var result = await this._mediator.Send(command);
      return Ok(result);
  }
```

## Classe de Validação

```c#
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
```

## Command Handler

```c#
  public async Task<Pessoa> Handle(CriarPessoaCommand request, CancellationToken cancellationToken)
  {
      var pessoa = new Pessoa
      {
          Nome = request.Nome,
          DataNascimento = request.DataNascimento,
          CPF = request.CPF
      };

      return await this._pessoaRepository.Add(pessoa);
  }
```
