using System;

namespace FluentValidationSampleCore
{
    public class Pessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
    }
}
