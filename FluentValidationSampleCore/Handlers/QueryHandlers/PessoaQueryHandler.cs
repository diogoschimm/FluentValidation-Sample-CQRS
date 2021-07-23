using FluentValidationSampleCore.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidationSampleCore.Handlers.QueryHandlers
{
    public class PessoaQueryHandler :
        IRequestHandler<ObterTodosClientesQuery, IEnumerable<Pessoa>>,
        IRequestHandler<ObterClientePorIdQuery, Pessoa>
    {
        private readonly IPessoaQuery _pessoaQuery;

        public PessoaQueryHandler(IPessoaQuery pessoaQuery)
        {
            this._pessoaQuery = pessoaQuery;
        }

        public Task<IEnumerable<Pessoa>> Handle(ObterTodosClientesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_pessoaQuery.GetAll());
        }

        public Task<Pessoa> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_pessoaQuery.GetById(request.Id));
        }
    }
}
