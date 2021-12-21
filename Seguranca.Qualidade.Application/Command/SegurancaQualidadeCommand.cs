namespace Segurança.Qualidade.Application.Command
{
    using MediatR;
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;

    public class SegurancaQualidadeCommand : IRequest<SegurancaQualidade>
    {
        public SegurancaQualidadeCommand(TipoRequisicao tipoRequisicao, string codigoNormasTecnicas, string codigoRisco)
        {
            TipoRequisicao = tipoRequisicao;
            CodigoNormasTecnicas = codigoNormasTecnicas;
            CodigoRisco = codigoRisco;
        }

        public string CodigoNormasTecnicas { get; set; }
        public string CodigoRisco { get; set; }
        public TipoRequisicao TipoRequisicao { get; set; }
    }
}
