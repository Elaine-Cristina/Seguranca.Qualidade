namespace Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate
{
    public class PlanoAcao
    {
        public PlanoAcao(string codigo, string planoAcao)
        {
            Codigo = codigo;
            Descricao = planoAcao;
        }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
