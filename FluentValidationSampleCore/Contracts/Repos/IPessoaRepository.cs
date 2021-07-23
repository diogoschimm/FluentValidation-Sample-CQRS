using System.Threading.Tasks;

namespace FluentValidationSampleCore
{
    public interface IPessoaRepository
    {
        Task<Pessoa> Add(Pessoa pessoa);
        Task<Pessoa> Update(Pessoa pessoa);
        Task<Pessoa> Delete(Pessoa pessoa);
    }
}
