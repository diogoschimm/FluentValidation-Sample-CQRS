using FluentValidationSampleCore;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidationSampleData
{
    public class PessoaQuery : IPessoaQuery
    {
        public IEnumerable<Pessoa> GetAll()
        {
            return Bd.Pessoas;
        }

        public Pessoa GetById(string id)
        {
            return Bd.Pessoas.FirstOrDefault(p => p.Id == id);
        }
    }
}
