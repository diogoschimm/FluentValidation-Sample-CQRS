using MediatR;
using System.Collections.Generic;

namespace FluentValidationSampleCore.Queries
{
    public class ObterTodosClientesQuery : IRequest<IEnumerable<Pessoa>>
    {
    }
}
