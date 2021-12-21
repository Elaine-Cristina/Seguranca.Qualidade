namespace Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate
{
    public interface ISegurancaQualidadeRepository
    {
        SegurancaQualidade ObterRiscosIdentificadosPorCodigo(string codigoNormasTecnicas);
        SegurancaQualidade ObterPlanoAcaoPorCodigo(string codigoNormasTecnicas, string codigoRisco);
    }
}
