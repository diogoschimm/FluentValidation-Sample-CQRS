using FluentValidationSampleCore.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidationSampleCore.Handlers.CommandHanlders
{
    public class PessoaCommandHandler :
        IRequestHandler<CriarPessoaCommand, Pessoa>,
        IRequestHandler<AtualizarPessoaCommand, Pessoa>,
        IRequestHandler<ExcluirPessoaCommand, Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaQuery _pessoaQuery;

        public PessoaCommandHandler(IPessoaRepository pessoaRepository, IPessoaQuery pessoaQuery)
        {
            this._pessoaRepository = pessoaRepository;
            this._pessoaQuery = pessoaQuery;
        }

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

        public async Task<Pessoa> Handle(AtualizarPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa
            {
                Id = request.Id,
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                CPF = request.CPF
            };

            return await this._pessoaRepository.Update(pessoa);
        }

        public async Task<Pessoa> Handle(ExcluirPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = this._pessoaQuery.GetById(request.Id);
            if (pessoa == null)
                throw new Exception("Pessoa não localizada");

            return await this._pessoaRepository.Delete(pessoa);
        }
    }
}
