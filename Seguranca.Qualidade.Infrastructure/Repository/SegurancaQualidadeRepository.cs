namespace Segurança.Qualidade.Infrastructure.Repository
{
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;
    using System.Collections.Generic;
    using System.Linq;

    public class SegurancaQualidadeRepository : ISegurancaQualidadeRepository
    {
        protected List<SegurancaQualidade> _segurancaQualidade;

        public SegurancaQualidadeRepository()
        {
            _segurancaQualidade = new List<SegurancaQualidade>();
        }

        public SegurancaQualidade ObterRiscosIdentificadosPorCodigo(string codigoNormasTecnicas)
        {
            _segurancaQualidade = new MockPrototipo.MockSegurancaQualidade().PopularRiscosIdentificados();
            return _segurancaQualidade.Where(x => x.CodigoNormasTecnicas == codigoNormasTecnicas).FirstOrDefault();
        }

        public SegurancaQualidade ObterPlanoAcaoPorCodigo(string codigoNormasTecnicas, string codigoRisco)
        {
            _segurancaQualidade = new MockPrototipo.MockSegurancaQualidade().PopularRiscosIdentificados();
            var seguranca = _segurancaQualidade.Where(x => x.CodigoNormasTecnicas == codigoNormasTecnicas).FirstOrDefault();
            seguranca.AnaliseRiscos.RemoveAll(x => x.Codigo != codigoRisco);

            return seguranca;
        }
    }
}
