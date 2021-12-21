namespace Segurança.Qualidade.Infrastructure.Repository
{
    using Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate;
    using System.Collections.Generic;
    using System.Linq;

    public class NormasTecnicasRepository : INormasTecnicasRepository
    {
        protected List<NormasTecnicas> _normasTecnicas;

        public NormasTecnicasRepository()
        {
            _normasTecnicas = new MockPrototipo.MockNormasTecnicas().PopularNormaTecnica();
        }

        public NormasTecnicas ObterNormaTecnicaPorCodigo(string codigo)
        {
            return _normasTecnicas.Where(x => x.Codigo == codigo).FirstOrDefault();
        }

        public void IncluirNormaTecnica(NormasTecnicas normaTecnica)
        {
            _normasTecnicas.Add(normaTecnica);
        }

        public void AlterarNormaTecnica(NormasTecnicas normaTecnica)
        {
            _normasTecnicas.RemoveAll(x => x.Codigo == normaTecnica.Codigo);
            _normasTecnicas.Add(normaTecnica);
        }
    }
}
