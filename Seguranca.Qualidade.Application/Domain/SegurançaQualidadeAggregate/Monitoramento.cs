namespace Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate
{
    public class Monitoramento
    {
        public Monitoramento(string descricao)
        { 
            Descricao = descricao;        
        }

        public string Descricao { get; set; }
    }
}
