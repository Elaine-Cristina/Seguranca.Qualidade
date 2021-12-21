namespace Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate
{
    public interface INormasTecnicasRepository
    {
        void AlterarNormaTecnica(NormasTecnicas normaTecnica);
        void IncluirNormaTecnica(NormasTecnicas normaTecnica);
        NormasTecnicas ObterNormaTecnicaPorCodigo(string codigo);
    }
}
