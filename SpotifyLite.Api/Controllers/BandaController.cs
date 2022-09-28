using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Application.Album.Handler.Command;
using SpotifyLite.Application.Album.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BandaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllBandaQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetBandaQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new CreateBandaCommand(dto));
            return Created($"{result.Banda.Id}", result.Banda);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateBandaCommand(dto));
            return Ok(result.Banda);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteBandaCommand(dto));
            return Ok(result.Banda);
        }

    }
}
