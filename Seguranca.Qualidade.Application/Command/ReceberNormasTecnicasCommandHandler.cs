namespace Segurança.Qualidade.Application.Command
{
    using MediatR;
    using Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ReceberNormasTecnicasCommandHandler : IRequestHandler<ReceberNormasTecnicasCommand, NormasTecnicas>
    {
        private readonly INormasTecnicasRepository _repository;

        public ReceberNormasTecnicasCommandHandler(INormasTecnicasRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<NormasTecnicas> Handle(ReceberNormasTecnicasCommand request, CancellationToken cancellationToken)
        {
            var normasTecnicas = _repository.ObterNormaTecnicaPorCodigo(request.NormasTecnicas.Codigo);

            if (normasTecnicas == null)
                _repository.IncluirNormaTecnica(request.NormasTecnicas);
            else
                _repository.AlterarNormaTecnica(request.NormasTecnicas);

            return Task.FromResult(request.NormasTecnicas);
        }
    }
}
