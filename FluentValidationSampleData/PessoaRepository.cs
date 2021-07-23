using FluentValidationSampleCore;
using System;
using System.Threading.Tasks;

namespace FluentValidationSampleData
{
    public class PessoaRepository : IPessoaRepository
    {
        public Task<Pessoa> Add(Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid().ToString();
            Bd.Pessoas.Add(pessoa);

            return Task.FromResult(pessoa);
        }

        public Task<Pessoa> Delete(Pessoa pessoa)
        {
            Bd.Pessoas.Remove(pessoa);

            return Task.FromResult(pessoa);
        }

        public Task<Pessoa> Update(Pessoa pessoa)
        {
            var index = Bd.Pessoas.FindIndex(p => p.Id == pessoa.Id);
            Bd.Pessoas[index] = pessoa;

            return Task.FromResult(pessoa);
        }
    }
}
