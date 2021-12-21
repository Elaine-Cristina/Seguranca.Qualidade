namespace Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate
{
    using System.Collections.Generic;

    public class SegurancaQualidade
    {
        public string CodigoNormasTecnicas { get; set; }

        public List<AnaliseRiscos> AnaliseRiscos { get; set; }
    }
}
