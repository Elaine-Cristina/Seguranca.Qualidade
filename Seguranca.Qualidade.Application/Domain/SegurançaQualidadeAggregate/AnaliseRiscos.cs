namespace Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate
{
    using System.Collections.Generic;

    public class AnaliseRiscos
    {
        public string Codigo{ get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<PlanoAcao> PlanoAcao { get; set; }
        public IList<Monitoramento> Monitoramento { get; set; }
    }
}
