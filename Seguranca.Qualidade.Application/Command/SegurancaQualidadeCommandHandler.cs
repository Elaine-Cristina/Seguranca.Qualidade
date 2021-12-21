namespace Segurança.Qualidade.Application.Command
{
    using MediatR;
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class SegurancaQualidadeCommandHandler : IRequestHandler<SegurancaQualidadeCommand, SegurancaQualidade>
    {
        private readonly ISegurancaQualidadeRepository _repository;

        public SegurancaQualidadeCommandHandler(ISegurancaQualidadeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<SegurancaQualidade> Handle(SegurancaQualidadeCommand request, CancellationToken cancellationToken)
        {
            var segurancaQualidade = new SegurancaQualidade();

            if (request.TipoRequisicao == TipoRequisicao.RiscosIdentificados)
                segurancaQualidade = _repository.ObterRiscosIdentificadosPorCodigo(request.CodigoNormasTecnicas);
            else if (request.TipoRequisicao == TipoRequisicao.PlanoAcao)
                segurancaQualidade = _repository.ObterPlanoAcaoPorCodigo(request.CodigoNormasTecnicas, request.CodigoRisco);

            return Task.FromResult(segurancaQualidade);
        }
    }
}
