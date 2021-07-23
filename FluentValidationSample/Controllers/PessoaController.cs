using FluentValidationSample.Controllers.Bases;
using FluentValidationSampleCore.Commands;
using FluentValidationSampleCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FluentValidationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ApiBase
    {
        public PessoaController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._mediator.Send(new ObterTodosClientesQuery());
            return Ok(result);
        }

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
    }
}
