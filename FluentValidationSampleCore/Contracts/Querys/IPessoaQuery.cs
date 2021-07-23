using System.Collections.Generic;

namespace FluentValidationSampleCore
{
    public interface IPessoaQuery
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(string id);
    }
}
