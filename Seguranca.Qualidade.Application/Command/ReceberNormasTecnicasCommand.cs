namespace Segurança.Qualidade.Application.Command
{
    using MediatR;
    using Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate;

    public class ReceberNormasTecnicasCommand : IRequest<NormasTecnicas>
    {
        public ReceberNormasTecnicasCommand(NormasTecnicas normasTecnicas)
        {
            NormasTecnicas = normasTecnicas;
        }

        public NormasTecnicas NormasTecnicas { get; set; }
    }
}
