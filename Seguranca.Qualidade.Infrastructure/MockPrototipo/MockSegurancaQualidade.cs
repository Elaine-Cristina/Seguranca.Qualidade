namespace Segurança.Qualidade.Infrastructure.MockPrototipo
{
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;
    using System.Collections.Generic;
    using System.Linq;

    public class MockSegurancaQualidade
    {
        public List<SegurancaQualidade> PopularRiscosIdentificados()
        {
            List<AnaliseRiscos> analiseRiscos = new List<AnaliseRiscos>()
            {
                new AnaliseRiscos()
                {
                    Codigo = "15800:1",
                    Titulo = "Tamanho Inadequado",
                    Descricao = "Evitar que o cliente adquira um produto com tamanho inadequado e eventualmente solicite a sua troca, causando um custo adicional.",
                    PlanoAcao = PopularPlanoAcaoRisco1(),
                    Monitoramento = PopularMonitoramentoRisco1()
                },
                new AnaliseRiscos()
                {
                    Codigo = "15800:2",
                    Titulo = "Usabilidade do Produto",
                    Descricao = "A facilidade em vestir e despir é fundamental. A roupa não deve oferecer dificuldade de mobilidade durante o uso.",
                    PlanoAcao = PopularPlanoAcaoRisco2(),
                    Monitoramento = PopularMonitoramentoRisco2()
                },
                new AnaliseRiscos()
                {
                    Codigo = "15800:3",
                    Titulo = "Peça desconfortável",
                    Descricao = "A peça deve ficar confortável ao corpo. As roupas devem sempre oferecer conforto e facilidade de movimento.",
                    PlanoAcao = PopularPlanoAcaoRisco3(),
                    Monitoramento = PopularMonitoramentoRisco3()
                }
            };

            var segurancaQualidade = new List<SegurancaQualidade>()
            {
                new SegurancaQualidade()
                {
                    CodigoNormasTecnicas = "ABNT NBR 15800:2009",
                    AnaliseRiscos = analiseRiscos
                }
            };

            return segurancaQualidade;
        }

        private List<PlanoAcao> PopularPlanoAcaoRisco1()
        {
            var planoAcaoRisco1 = new List<PlanoAcao>()
            {
                new PlanoAcao("15800:1:1", "Padronizar os tamanhos das roupas fabricadas"),
            };

            return planoAcaoRisco1;
        }

        private List<PlanoAcao> PopularPlanoAcaoRisco2()
        {
            var planoAcaoRisco2 = new List<PlanoAcao>()
            {
                new PlanoAcao("15800:2:2", "Desenvolver modelos ergonômicos e esteticamente agradáveis"),
            };

            return planoAcaoRisco2;
        }

        private List<PlanoAcao> PopularPlanoAcaoRisco3()
        {
            var planoAcaoRisco3 = new List<PlanoAcao>()
            {
                new PlanoAcao("15800:3:3", "Modelagem adequado ao biotipo do público alvo"),
            };

            return planoAcaoRisco3;
        }

        private List<Monitoramento> PopularMonitoramentoRisco1()
        {
            var monitorarRisco1 = new List<Monitoramento>()
            {
                new Monitoramento("Analisar as roupas fabricadas, para verificar se estão nos tamanhos padrões estabelecidos.")
            };

            return monitorarRisco1;
        }

        private List<Monitoramento> PopularMonitoramentoRisco2()
        {
            var monitorarRisco2 = new List<Monitoramento>()
            {
                new Monitoramento("Analisar as roupas fabricadas, para verificar se os modelos ergonômicos e esteticamente agradáveis")
            };

            return monitorarRisco2;
        }

        private List<Monitoramento> PopularMonitoramentoRisco3()
        {
            var monitorarRisco3 = new List<Monitoramento>()
            {
                new Monitoramento("Analisar as roupas fabricadas, para verificar se a modelagem adequado ao biotipo do público alvo")
            };

            return monitorarRisco3;
        }
    }
}
