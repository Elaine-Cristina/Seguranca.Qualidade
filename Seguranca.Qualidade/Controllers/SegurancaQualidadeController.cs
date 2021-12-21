namespace Segurança.Qualidade.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Segurança.Qualidade.Application.Command;
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SegurancaQualidadeController : ControllerBase
    {
        readonly IMediator _mediator;

        public SegurancaQualidadeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("RiscosIdentificados/{codigoNormaTecnica}", Name = "GetRiscosIdentificados")]
        public async Task<ActionResult> GetRiscosIdentificados([FromRoute(Name = "codigoAcesso")] string codigoAcesso,
                                                               [FromRoute(Name = "codigoNormaTecnica")] string codigoNormaTecnica)
        {
            var result = await _mediator.Send(new SegurancaQualidadeCommand(TipoRequisicao.RiscosIdentificados, codigoNormaTecnica, null));

            if (result == null)
                return await Task.FromResult<NotFoundObjectResult>(null);

            return await Task.FromResult(Ok(result));
        }

        [HttpGet("PlanoAcao/{codigoNormaTecnica}/{codigoRisco}", Name = "GetPlanoAcao")]
        public async Task<ActionResult> GetPlanoAcao([FromRoute(Name = "codigoAcesso")] string codigoAcesso,
                                                     [FromRoute(Name = "codigoNormaTecnica")] string codigoNormaTecnica,
                                                     [FromRoute(Name = "codigoRisco")] string codigoRisco)
        {
            var result = await _mediator.Send(new SegurancaQualidadeCommand(TipoRequisicao.PlanoAcao, codigoNormaTecnica, codigoRisco));

            if (result == null)
                return await Task.FromResult<NotFoundObjectResult>(null);

            return await Task.FromResult(Ok(result));
        }
    }
}
