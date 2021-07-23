using MediatR;

namespace FluentValidationSampleCore.Queries
{
    public class ObterClientePorIdQuery : IRequest<Pessoa>
    {
        public ObterClientePorIdQuery(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
